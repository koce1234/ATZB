using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Data;
using ATZB.Data.DataContext;
using ATZB.Domain;
using ATZB.Services.ApplicationServices;
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
        private readonly ATZBDbContext _dbContext;
        private readonly IOrderService _orderService;

        public OrderController(ATZBDbContext dbContext
        ,IOrderService orderService)
        {
            this._dbContext = dbContext;
            this._orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var getAllUsers = await _orderService.GetAllOrdersAsync();

            return Ok(getAllUsers);
        }

        


    }
}