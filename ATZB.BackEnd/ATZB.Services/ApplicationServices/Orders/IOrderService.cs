using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Domain.Models;

namespace ATZB.Services.ApplicationServices.Orders
{
    public interface IOrderService
    {
        Task<List<ATZBOrder>> GetAllOrdersAsync();

        Task<ATZBOrder> RegisterOrderAsync(ATZBOrder order);

        Task<List<ATZBOrder>> GetAllOrdersByUserIdAsync(string userId);

    }
}
