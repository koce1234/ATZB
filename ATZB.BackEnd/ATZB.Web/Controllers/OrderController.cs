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
        //TODO :
        //1 .GetAllOrders
        //2 . Add
        //3 .ReturnAllbyUserId
        //4 . FilterBy
        //5. AllOrdersByCity
        
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
          
            this._orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrders = await _orderService.GetAllOrdersAsync();

            return Ok(allOrders);
        }

        [HttpPost("register")]
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
               Type = addOrderBindingModel.Type
            };

            await _orderService.RegisterOrderAsync(order);

            return Ok();
        }

        //TODO: RADO NEED CHECK
        [HttpGet]
        public async Task<IActionResult> ReturnAllOrdersByUserId(string userId)
        {
            var orders = await _orderService.GetAllOrderByUserId(userId);

            return Ok(orders);
        } 




    }
}