using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Data;
using ATZB.Data.DataContext;
using ATZB.Domain;
using ATZB.Services.ApplicationServices;
using ATZB.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATZB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
          
            this._orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await _orderService.GetAllOrdersAsync();

            return Ok(allOrders);
        }

        [HttpPost("AddOrder")]
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