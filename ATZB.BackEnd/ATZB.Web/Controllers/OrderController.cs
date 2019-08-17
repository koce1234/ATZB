using System.Linq;
using ATZB.Domain.Models;

namespace ATZB.Web.Controllers
{
    using System.Threading.Tasks;
    using ATZB.Domain;
    using ATZB.Services.ApplicationServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await _orderService.GetAllOrdersAsync();

            return Ok(allOrders);
        }


        //TODO: RADO NEED CHECK
        [Authorize]
        [HttpGet("myOrders")]
        public async Task<IActionResult> ReturnAllOrdersByUserIdAsync([FromHeader]string userId)
        {
            var orders = await _orderService.GetAllOrderByUserIdAsync(userId);

            return Ok(orders);
        }

        [Authorize]
        [HttpGet("filterBy")]
        public async Task<IActionResult> FilterByAsync()
        {
            return BadRequest("Not implemented yet!");
        }

        [Authorize]
        [HttpGet("orderByCity")]
        public async Task<IActionResult> OrderByCityAsync(string city)
        {
            if (city == null)
            {
                return BadRequest(GlobalConstants.InvalidCityControllerErrorMsg);
            }
            return  this.Ok(_orderService.GetAllOrdersAsync().Result.Where(o => o.Town == city));
        }

        [Authorize]
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrderAsync([FromBody]AddOrderBindingModel addOrderBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GlobalConstants.InvalidModelControllerErrorMsg);
            }

            var order = new ATZBOrder
            {
               Description = addOrderBindingModel.Description,
               PriceTo = addOrderBindingModel.PriceTo,
               Town = addOrderBindingModel.Town,
               TypeForOrder = addOrderBindingModel.TypeOfOrder
            };

            await _orderService.RegisterOrderAsync(order);

            return Ok();
        }





    }
}