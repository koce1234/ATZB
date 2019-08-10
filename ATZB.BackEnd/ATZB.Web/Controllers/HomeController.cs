using Microsoft.AspNetCore.Mvc;

namespace ATZB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Home()
        {
            return Ok();
        }
    }
}