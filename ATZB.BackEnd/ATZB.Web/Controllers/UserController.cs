using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Domain;
using ATZB.Domain.Models;
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
        private readonly ICompanyService _companyService;
        private readonly ICloudDinaryService _cloudinaryService;

        public UserController(
           IPasswordHasherService passwordHasherService,
           IUserService userService,
           ICompanyService companyService,
           ICloudDinaryService cloudinaryService)
        {
            this._passwordHasherService = passwordHasherService;
            _userService = userService;
            _companyService = companyService;
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
                PasswordSalt = hashedPassword.Value
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
            if (!this.ModelState.IsValid && int.TryParse(registerCompanyBindingModel.DirectorPrsonalDocumentNumber, out int kur))
            {
                return BadRequest();
            }

            var newCompany = new Company()
            {
                DirectorPrsonalDocumentNumber = int.Parse(registerCompanyBindingModel.DirectorPrsonalDocumentNumber),
                ENK = registerCompanyBindingModel.ENK,
                DDSNumber = registerCompanyBindingModel.DDSNumber,
                Mol = registerCompanyBindingModel.Mol,
                RegKSB = registerCompanyBindingModel.RegKSB,
                AnyObligation = registerCompanyBindingModel.AnyObligation,
                UserId = userId
            };

            _companyService.RegisterCompany(userId, newCompany);
            return Ok();
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
                return Ok(new { token = userAndToken.Value, userId = userAndToken.Key.Id, fullName = userAndToken.Key.FirstName + ' ' + userAndToken.Key.LastName });
            }
        }


        private async Task<List<string>> GetLinks(List<IFormFile> images, string fullName)
        {
            List<IFormFile> uploadedImages = new List<IFormFile>();

            uploadedImages.AddRange(images);

            List<string> uploadedImagesLinks = new List<string>();

            foreach (var uploadedImage in uploadedImages)
            {
                string newImageName = fullName;
                string imageLink = await _cloudinaryService.CreateImageAsync(uploadedImage, newImageName);
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


        private bool CheckConfirmPasswordWithPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }

            return false;
        }

    }
}