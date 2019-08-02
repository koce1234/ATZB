namespace ATZB.Web.Controllers
{
    using System.Threading.Tasks;
    using ATZB.Domain;
    using ATZB.Services.ApplicationServices;
    using ATZB.Web.Controllers.Dto_s;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPasswordHasherService _PasswordHasherService;
        private readonly IUserService _userService;

        public UserController(
           IPasswordHasherService _passwordHasherService,
            IUserService userService)
        {
            _PasswordHasherService = _passwordHasherService;
            _userService = userService;
        }
        //TODO : May remove async
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUsers = await _userService.GetAllUsers();

            return Ok(getAllUsers);
        } 
        //TODO Rado: need 4 views each one is for the diffrent type user registration
        //TODO Rado: when user go to the register page set by default the usertype
        //TODO Koce: implement 4 prive methods for each registration

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterBidingModel userForRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isEmailAlreadyExisting = await _userService.EmailAlreadyExist(userForRegisterDto.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest();
            }

            var hashedPassword = await _PasswordHasherService.HashPassword(userForRegisterDto.Password);
           
            
            var user = new ATZBUser
            {
                Name = userForRegisterDto.FullName,
                Address = userForRegisterDto.Address,
                EGN = userForRegisterDto.EGN,
                LKNummber = userForRegisterDto.LKNumber,
                Phone = userForRegisterDto.Phone,
                ENK = userForRegisterDto.ENK,
                DDSNumber = userForRegisterDto.DDSNumber,
                RegKSB = userForRegisterDto.RegKSB,
                AnyObligations = userForRegisterDto.AnyObligations,
                Email = userForRegisterDto.Email,
                PasswordHash = hashedPassword.Key,
                PasswordSalt = hashedPassword.Value
            };

            await _userService.CreateUser(user);
         
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            var userAndToken = await _userService
                .GetUserByUsernameAndPassword(userForLogInDto.Email,userForLogInDto.Password);


            if (userAndToken.Key == null)
            {
                return BadRequest("Email or password is incorrect!");
            }
            else
            {
                return Ok(new { userAndToken.Value });
            }
        }
    }
}