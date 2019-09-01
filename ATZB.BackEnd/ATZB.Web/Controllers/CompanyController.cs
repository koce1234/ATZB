namespace ATZB.Web.Controllers
{
    using ATZB.Domain.Models;
    using ATZB.Services.ApplicationServices;
    using ATZB.Web.ViewModels.UserTypeRegisters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CompanysHomePage()
        {
            return BadRequest("Not Implemented Yet");
        }

        [Authorize]
        [HttpGet("seeAllAvilableOffers")]
        public async Task<IActionResult> SeeAvailableOffers()
        {
            return BadRequest("Not Implemented Yet");
        }

        [Authorize]
        [HttpPost("createOffer")]
        public async Task<IActionResult> CreateOffer()
        {
            return BadRequest("Not Implemented Yet");
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
    }
}