using ATZB.Services.BaseServices;
using ATZB.Services.ApplicationServices;
using ATZB.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATZB.Web.Controllers.Dto_s;

namespace ATZB.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IUserService _userService;

        public UserController(
           IPasswordHasherService passwordHasherService,
            IUserService userService)
        {
            this._passwordHasherService = passwordHasherService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var getAllUsers = await _userService.GetAllUsers();

            return Ok(getAllUsers);
        }

        [HttpPost("registerAsClient")]
        public async Task<IActionResult> RegisterAsClient([FromBody]UserForRegisterBidingModel userForRegisterDto)
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

            var hashedPassword = await _passwordHasherService.HashPasswordAsync(userForRegisterDto.Password);


            var user = new ATZBUser
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                StreetAddress = userForRegisterDto.StreetAddress,
                City = userForRegisterDto.City,
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

        [HttpPost("registerAsPerformer")]
        public async Task<IActionResult> RegisterAsPerformer()
        {
            return BadRequest("Implementation needed!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            var userAndToken = await _userService
                .GetUserByUsernameAndPassword(userForLogInDto.Email, userForLogInDto.Password);


            if (userAndToken.Key == null)
            {
                return BadRequest("Email or password is incorrect!");
            }
            else
            {
                return Ok(new { token = userAndToken.Value, userId = userAndToken.Key.Id });
            }
        }
    }
}