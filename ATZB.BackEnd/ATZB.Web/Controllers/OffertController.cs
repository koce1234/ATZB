using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;
using ATZB.Services.ApplicationServices.Offerts;
using ATZB.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATZB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffertController : ControllerBase
    {
        private readonly IOffertService _offertService;

        public OffertController(IOffertService offertService)
        {
            this._offertService = offertService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOffertsAsync()
        {
            var allOrders = await _offertService.GetAllOffertsAsync();

            return Ok(allOrders);
        }


        //TODO: RADO NEED CHECK
        [Authorize]
        [HttpGet("myOfferts")]
        public async Task<IActionResult> ReturnAllOffertsByUserIdAsync([FromHeader]string userId)
        {
            var orders = await _offertService.GetAllOffertsByUserIdAsync(userId);

            return Ok(orders);
        }

        

        [Authorize]
        [HttpGet("offertByCity")]
        public async Task<IActionResult> OffertByCityAsync(Cities city)
        {
            if (city == null)
            {
                return BadRequest(GlobalConstants.InvalidCityControllerErrorMsg);
            }
            return this.Ok(_offertService.GetAllOffertsAsync().Result.Where(o => o.City == city));
        }

        [Authorize]
        [HttpPost("addOffert")]
        public async Task<IActionResult> AddOffertAsync([FromBody]AddOffertBindingModel addOffertBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var offert = new ATZBOffert
            {
                Description = addOffertBindingModel.Description,
                Price = addOffertBindingModel.Price,
                City = addOffertBindingModel.City,
                TypeForOfferts = addOffertBindingModel.TypeOfOfferts
            };

            await _offertService.RegisterOffertAsync(offert);

            return Ok();
        }
    }
}