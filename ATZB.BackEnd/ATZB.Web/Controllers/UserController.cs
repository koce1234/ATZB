namespace ATZB.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using ATZB.Data;
    using ATZB.Domain;
    using ATZB.Services.ApplicationServices;
    using ATZB.Web.Controllers.Dto_s;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IPasswordValidatorService _passwordValidatorService;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public UserController(
            ATZBDbContext dbContext, 
            IPasswordHasherService passwordHasherService,
            IPasswordValidatorService passwordValidatorService,
            ITokenGeneratorService tokenGeneratorService)
        {
            _dbContext = dbContext;
            _passwordHasherService = passwordHasherService;
            _passwordValidatorService = passwordValidatorService;
            _tokenGeneratorService = tokenGeneratorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUsers = _dbContext.Users.ToList();

            return Ok(getAllUsers);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterBidingModel userForRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isEmailAlreadyExisting = _dbContext.Users.Any(x => x.Email == userForRegisterDto.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest();
            }

            var hashedPassword = _passwordHasherService.HashPassword(userForRegisterDto.Password);

            var newUser = new ATZBUser
            {
                Name = userForRegisterDto.FullName,
                Adress = userForRegisterDto.Adress,
                EGN = userForRegisterDto.EGN,
                LKNummber = userForRegisterDto.LKNumber,
                Phone = userForRegisterDto.Phone,
                ENK = userForRegisterDto.ENK,
                DDSNumber = userForRegisterDto.DDSNumber,
                RegKSB = userForRegisterDto.RegKSB,
                AnyObligations = userForRegisterDto.AnyObligations,
                Email = userForRegisterDto.Email,
                PasswordHash = hashedPassword.hashedPassword,
                PasswordSalt = hashedPassword.saltBytes
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            var findUser = _dbContext.Users.FirstOrDefault(x => x.Email == userForLogInDto.Email);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (findUser == null)
            {
                return BadRequest("Email or password is incorrect!");
            }

            var validatePassword = _passwordValidatorService
                .CompareHash(userForLogInDto.Password, findUser.PasswordHash, findUser.PasswordSalt);

            if (validatePassword)
            {
                var token = _tokenGeneratorService.GenerateJWT(findUser.Id, findUser.Email);

                return Ok(new { token });
            }
            else
            {
                return BadRequest("Email or password is incorrect!");
            }
        }
    }
}