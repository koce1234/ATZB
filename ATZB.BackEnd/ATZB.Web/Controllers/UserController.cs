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
            var getAllUsers = this._userService.GetAllUsers();

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

            var isEmailAlreadyExisting = _userService.EmailAlreadyExist(userForRegisterDto.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest();
            }

            var hashedPassword = this._PasswordHasherService.HashPassword(userForRegisterDto.Password);
           
            
            var user = new ATZBUser
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

            this._userService.CreateUser(user);
         
            return Ok();
        }
        //TODO : May remove async
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            var userAndToken = this._userService
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