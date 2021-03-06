﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;
using ATZB.Services.ApplicationServices.Users;
using ATZB.Services.BaseServices;
using ATZB.Web.Controllers.Dto_s;
using ATZB.Web.ViewModels;
using ATZB.Web.ViewModels.UserTypeRegisters;
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

        [HttpPost("RegisterClient")]
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
               Adress = clientForRegisterBM.Adress,
               EGN = clientForRegisterBM.EGN,
               LKNummber = clientForRegisterBM.LkNumber,
               AnyObligations = clientForRegisterBM.AnyObligations,
               PasswordHash = hashedPassword.Key,
               PasswordSalt =  hashedPassword.Value,
               City = clientForRegisterBM.City,
               Email = clientForRegisterBM.Email
            };

            await _userService.CreateUserAsync(user);
         
            return Ok();
        }

        [HttpPost("RegisterClientCompany")]
        public async Task<IActionResult> RegisterClientCompanyAsync([FromBody] ClientCompanyBindingModel clientCompanyForRegisterBM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var isEmailAlreadyExisting = await _userService.EmailAlreadyExistAsync(clientCompanyForRegisterBM.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest(GlobalConstants.EmailAlreadyExistErrorMsg);
            }

            var hashedPassword = await _passwordHasherService.HashPasswordAsync(clientCompanyForRegisterBM.Password);

            if (!CheckConfirmPasswordWithPassword(clientCompanyForRegisterBM.Password, clientCompanyForRegisterBM.ConfirmPassword))
            {
                return BadRequest(GlobalConstants.InvalidPasswordErrorMsg);
            }

            var user = new ATZBUser
            {
                CompanyName = clientCompanyForRegisterBM.CompanyName,
               Adress = clientCompanyForRegisterBM.Adress,
               ENK = clientCompanyForRegisterBM.ENK,
               DDSNumber = clientCompanyForRegisterBM.DDSNum,
               RegKSB =  clientCompanyForRegisterBM.REGKSB,
               Mol = clientCompanyForRegisterBM.Mol,
               AnyObligations = clientCompanyForRegisterBM.AnyObligations,
               PasswordHash = hashedPassword.Key,
               PasswordSalt =  hashedPassword.Value,
               City = clientCompanyForRegisterBM.City,
               Email = clientCompanyForRegisterBM.Email
            };

            await _userService.CreateUserAsync(user);
         
            return Ok();
        }

        [HttpPost("RegisterContractorCompany")]
        public async Task<IActionResult> RegisterContractorCompanyAsync([FromBody] ContractorCompanyRegisterBindingModel contractorCompanyForRegisterBM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var isEmailAlreadyExisting = await _userService.EmailAlreadyExistAsync(contractorCompanyForRegisterBM.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest(GlobalConstants.EmailAlreadyExistErrorMsg);
            }

            List<IFormFile> uploadedImages = new List<IFormFile>();

            uploadedImages.AddRange(contractorCompanyForRegisterBM.Images);

            

            List<string> uploadedImagesLinks = GetLinks
                (
                    uploadedImages
                    , contractorCompanyForRegisterBM.CompanyName
                )
                .Result;


            var hashedPassword = await _passwordHasherService.HashPasswordAsync(contractorCompanyForRegisterBM.Password);

            if (!CheckConfirmPasswordWithPassword(contractorCompanyForRegisterBM.Password, contractorCompanyForRegisterBM.ConfirmPassword))
            {
                return BadRequest(GlobalConstants.InvalidPasswordErrorMsg);
            }

            var user = new ATZBUser
            {
                CompanyName = contractorCompanyForRegisterBM.CompanyName,
                Adress = contractorCompanyForRegisterBM.Adress,
                ENK = contractorCompanyForRegisterBM.ENK,
                DDSNumber = contractorCompanyForRegisterBM.DDSNum,
                RegKSB = contractorCompanyForRegisterBM.REGKSB,
                Mol = contractorCompanyForRegisterBM.Mol,
                AnyObligations = contractorCompanyForRegisterBM.AnyObligations,
                PasswordHash = hashedPassword.Key,
                PasswordSalt = hashedPassword.Value,
                City = contractorCompanyForRegisterBM.City,
                Email = contractorCompanyForRegisterBM.Email,
                ImagesLinks = FillImagesCollection(uploadedImagesLinks),
                TypeOfSpecials = FillTypeSpecialCollection(contractorCompanyForRegisterBM.TypeOfSpecials)
            };


            await _userService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPost("RegisterPrivatePerson")]
        public async Task<IActionResult> RegisterPrivatePersonAsync([FromBody]PrivatePersonRegisterBindingModel privatePersonForRegisterBM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var isEmailAlreadyExisting = await _userService.EmailAlreadyExistAsync(privatePersonForRegisterBM.Email);

            if (isEmailAlreadyExisting)
            {
                return BadRequest(GlobalConstants.EmailAlreadyExistErrorMsg);
            }
            List<IFormFile> uploadedImages = new List<IFormFile>();

            uploadedImages.AddRange(privatePersonForRegisterBM.Images);

            List<string> uploadedImagesLinks = GetLinks
                    (
                      uploadedImages
                    , privatePersonForRegisterBM.FirstName + "/" + privatePersonForRegisterBM.LastName
                    
                    )
                     .Result;
            
            var hashedPassword = await _passwordHasherService.HashPasswordAsync(privatePersonForRegisterBM.Password);

            if (!CheckConfirmPasswordWithPassword(privatePersonForRegisterBM.Password , privatePersonForRegisterBM.ConfirmPassword))
            {
                return BadRequest(GlobalConstants.InvalidPasswordErrorMsg);
            }
            

            var user = new ATZBUser
            {
                FirstName = privatePersonForRegisterBM.FirstName,
                LastName = privatePersonForRegisterBM.LastName,
                Adress = privatePersonForRegisterBM.Adress,
                EGN = privatePersonForRegisterBM.EGN,
                LKNummber = privatePersonForRegisterBM.LkNumber,
                AnyObligations = privatePersonForRegisterBM.AnyObligations,
                PasswordHash = hashedPassword.Key,
                PasswordSalt = hashedPassword.Value,
                City = privatePersonForRegisterBM.City,
                Email = privatePersonForRegisterBM.Email,
                ImagesLinks = FillImagesCollection(uploadedImagesLinks),
                TypeOfSpecials = FillTypeSpecialCollection(privatePersonForRegisterBM.TypeOfSpecials)
            };
            
            await _userService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPost("Login")]
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

        private List<TypeSpecial> FillTypeSpecialCollection(ICollection<TypeOfSpecial> typeSpecials)
        {
            var typeSpecialsCollection = new List<TypeSpecial>();


            foreach (var typeSpecial in typeSpecials)
            {
                typeSpecialsCollection.Add(new TypeSpecial(typeSpecial));
            }

            return typeSpecialsCollection;
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