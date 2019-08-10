using ATZB.Services.BaseServices;

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
<<<<<<< .merge_file_a14836
            var getAllUsers = await _userService.GetAllUsers();
=======
            var getAllUsers = await _userService.GetAllUsersAsync();
>>>>>>> .merge_file_a15820

            return Ok(getAllUsers);
        } 

<<<<<<< .merge_file_a14836
        [HttpPost("registerAsClient")]
        public async Task<IActionResult> RegisterAsClient([FromBody]UserForRegisterBidingModel userForRegisterDto)
=======
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserForRegisterBidingModel userForRegisterDto)
>>>>>>> .merge_file_a15820
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

<<<<<<< .merge_file_a14836
            var isEmailAlreadyExisting = await _userService.EmailAlreadyExist(userForRegisterDto.Email);
=======
            var isEmailAlreadyExisting = await _userService.EmailAlreadyExistAsync(userForRegisterDto.Email);
>>>>>>> .merge_file_a15820

            if (isEmailAlreadyExisting)
            {
                return BadRequest();
            }

<<<<<<< .merge_file_a14836
            var hashedPassword = await _PasswordHasherService.HashPassword(userForRegisterDto.Password);
=======
            var hashedPassword = await _passwordHasherService.HashPasswordAsync(userForRegisterDto.Password);
>>>>>>> .merge_file_a15820
           
            
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

<<<<<<< .merge_file_a14836
            await _userService.CreateUser(user);
=======
            await _userService.CreateUserAsync(user);
>>>>>>> .merge_file_a15820
         
            return Ok();
        }

<<<<<<< .merge_file_a14836
        [HttpPost("registerAsPerformer")]
        public async Task<IActionResult> RegisterAsPerformer()
        {
            return BadRequest("Implementation needed!");
        }

=======
>>>>>>> .merge_file_a15820
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            var userAndToken = await _userService
<<<<<<< .merge_file_a14836
                .GetUserByUsernameAndPassword(userForLogInDto.Email,userForLogInDto.Password);
=======
                .GetUserByEmailAndPasswordAsync(userForLogInDto.Email,userForLogInDto.Password);
>>>>>>> .merge_file_a15820


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