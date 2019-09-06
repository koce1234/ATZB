using ATZB.Data.DataContext;
using ATZB.Domain.Models;
using ATZB.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATZB.Services.ApplicationServices.Offerts
{
    public class OffertService : IOffertService
    {
        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordValidatorService _passwordValidator;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public OffertService(ATZBDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public OffertService(ATZBDbContext dbContext
            , IPasswordValidatorService passwordValidator
            , ITokenGeneratorService tokenGeneratorService)
        {
            _dbContext = dbContext;
            _passwordValidator = passwordValidator;
            _tokenGeneratorService = tokenGeneratorService;
        }
        public async Task<List<ATZBOffert>> GetAllOffertsAsync()
        => await _dbContext.Offerts.ToListAsync();

        public async Task<List<ATZBOffert>> GetAllOffertsByUserIdAsync(string userId)
       => await _dbContext.Offerts.Where(o => o.UserId == userId).ToListAsync();

        public async Task<ATZBOffert> RegisterOffertAsync(ATZBOffert offert)
        {
            await _dbContext.Offerts.AddAsync(offert);
            await _dbContext.SaveChangesAsync();

            return offert;
        }
    }
}
