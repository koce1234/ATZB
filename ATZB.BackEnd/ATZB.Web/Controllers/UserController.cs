using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Domain;
using ATZB.Services.ApplicationServices;
using ATZB.Services.BaseServices;
using ATZB.Web.Controllers.Dto_s;
using ATZB.Web.ViewModels.UserTypeRegisters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATZB.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IUserService _userService;
        private readonly ICloudDinaryService _cloudinaryService;

        public UserController(
           IPasswordHasherService passwordHasherService,
            IUserService userService
           ,ICloudDinaryService cloudinaryService)
        {
            this._passwordHasherService = passwordHasherService;
            _userService = userService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var getAllUsers = await _userService.GetAllUsersAsync();

            return Ok(getAllUsers);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterClientAsync([FromBody]ClientRegisterdBindingModel clientForRegisterBM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var isEmailAlreadyExisting = await _userService.EmailAlreadyExistAsync(clientForRegisterBM.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest(GlobalConstants.EmailAlreadyExistErrorMsg);
            }

            var hashedPassword = await _passwordHasherService.HashPasswordAsync(clientForRegisterBM.Password);

            if (!CheckConfirmPasswordWithPassword(clientForRegisterBM.Password, clientForRegisterBM.ConfirmPassword))
            {
                return BadRequest(GlobalConstants.InvalidPasswordErrorMsg);
            }

            var user = new ATZBUser
            {
               FirstName = clientForRegisterBM.FirstName,
               LastName = clientForRegisterBM.LastName,
               StreetAdress = clientForRegisterBM.StreetAdress,
               EGN = clientForRegisterBM.EGN,
               City = clientForRegisterBM.City,
               Phone = clientForRegisterBM.Phone,
               Email = clientForRegisterBM.Email,
               PasswordHash = hashedPassword.Key,
               PasswordSalt =  hashedPassword.Value
            };

            await _userService.CreateUserAsync(user);
         
            return Ok();
        }

        [Authorize]
        [HttpPost("registerCompany")]
        public async Task<IActionResult> CreateCompany(
            [FromHeader] string userId,
            [FromBody] RegisterCompanyBindingModel registerCompanyBindingModel)
        {
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserForLogInBindingModel userForLogInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var userAndToken = await _userService
                .GetUserByUsernameAndPasswordAsync(userForLogInDto.Email, userForLogInDto.Password);


            if (userAndToken.Key == null)
            {
                return BadRequest(GlobalConstants.EmailOrPasswordIsIncorrectErrorMsg);
            }
            else
            {
                return Ok(new { token = userAndToken.Value, userId = userAndToken.Key.Id, fullName = userAndToken.Key.FirstName + ' ' +userAndToken.Key.LastName });
            }
        }


        private async Task<List<string>> GetLinks(List<IFormFile> images , string fullName )
        {
            List<IFormFile> uploadedImages = new List<IFormFile>();

            uploadedImages.AddRange(images);

            List<string> uploadedImagesLinks = new List<string>();

            foreach (var uploadedImage in uploadedImages)
            {
                string newImageName = fullName;
                string imageLink =  await _cloudinaryService.CreateImageAsync(uploadedImage, newImageName);
                uploadedImagesLinks.Add(imageLink);
            }

            return uploadedImagesLinks;
        }


        private List<Image> FillImagesCollection(List<string> uploadedImagesLinks)
        {
            var imagesCollection = new List<Image>();
            

            foreach (var uploadedImagesLink in uploadedImagesLinks)
            {
                imagesCollection.Add(new Image(uploadedImagesLink));
            }

            return imagesCollection;
        }


        private bool CheckConfirmPasswordWithPassword(string password , string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }

            return false;
        }

    }
}