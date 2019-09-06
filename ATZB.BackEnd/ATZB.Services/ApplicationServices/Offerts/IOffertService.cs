using ATZB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATZB.Services.ApplicationServices.Offerts
{
    public interface IOffertService
    {
        Task<List<ATZBOffert>> GetAllOffertsAsync();


        Task<ATZBOffert> RegisterOffertAsync(ATZBOffert order);

        Task<List<ATZBOffert>> GetAllOffertsByUserIdAsync(string userId);
    }
}
