using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Data.DataContext;
using ATZB.Domain.Models;
using ATZB.Services.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Services.ApplicationServices.Orders
{
    public class OrderService : IOrderService
    {

        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordValidatorService _passwordValidator;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public OrderService(ATZBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public OrderService(ATZBDbContext dbContext
            , IPasswordValidatorService passwordValidator
            , ITokenGeneratorService tokenGeneratorService)
        {
            _dbContext = dbContext;
            _passwordValidator = passwordValidator;
            _tokenGeneratorService = tokenGeneratorService;
        }


        public async Task<List<ATZBOrder>> GetAllOrdersAsync()
        => await _dbContext.Orders.ToListAsync();


        public async Task<ATZBOrder> RegisterOrderAsync(ATZBOrder order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<List<ATZBOrder>> GetAllOrdersByUserIdAsync(string userId)
            => await _dbContext.Orders.Where(u => u.UserId == userId).ToListAsync();
    }
}
