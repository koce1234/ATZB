namespace ATZB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CompanysHomePage()
        {
            return BadRequest("Not Implemented Yet");
        }

        [Authorize]
        [HttpGet]
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
    }
}