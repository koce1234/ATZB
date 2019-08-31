namespace ATZB.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLastestNews()
        {
            return BadRequest("Not Implemented Yet");
        }
    }
}