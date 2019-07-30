using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Data.DataContext;
using ATZB.Domain;
using ATZB.Services.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Services.ApplicationServices
{
    public class OrderService
    {

        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordValidatorService _passwordValidator;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public OrderService(ATZBDbContext dbContext)
        {
            this._dbContext = dbContext;
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
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return orders;
        }


    }
}
