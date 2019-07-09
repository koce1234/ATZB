using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Data;
using ATZB.Domain;
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
        private readonly ATZBDbContext dbContext;

        public OrderController(ATZBDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     
        // This method returns all orders
        

        //TODO: May have changes
        //TODO: I dont think its good practice to get 

    }
}