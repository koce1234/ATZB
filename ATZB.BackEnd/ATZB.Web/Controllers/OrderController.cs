using ATZB.Domain.Models;

namespace ATZB.Web.Controllers
{
    using System.Threading.Tasks;
    using ATZB.Domain;
    using ATZB.Services.ApplicationServices;
    using ATZB.Web.Controllers.Dto_s;
    using ATZB.Web.ViewModels;
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
        public async Task<IActionResult> ReturnAllOrdersByUserId([FromHeader]string userId)
        {
            var orders = await _orderService.GetAllOrderByUserIdAsync(userId);

            return Ok(orders);
        }

        [Authorize]
        [HttpGet("filterBy")]
        public async Task<IActionResult> FilterBy()
        {
            return BadRequest("Not implemented yet!");
        }

        [Authorize]
        [HttpGet("orderByCity")]
        public async Task<IActionResult> OrderByCity(string city)
        {
            return BadRequest("Not implemented yet!");
        }

        [Authorize]
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrderAsync([FromBody]AddOrderBindingModel addOrderBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
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

        //TODO: RADO NEED CHECK
        [HttpGet]
        public async Task<IActionResult> ReturnAllOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderService.GetAllOrderByUserIdAsync(userId);

            return Ok(orders);
        } 




    }
}