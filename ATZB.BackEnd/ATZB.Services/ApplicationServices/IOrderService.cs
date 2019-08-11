using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Domain;

namespace ATZB.Services.ApplicationServices
{
    public interface IOrderService
    {
        Task<List<ATZBOrder>> GetAllOrdersAsync();


        Task<ATZBOrder> RegisterOrderAsync(ATZBOrder order);

        Task<List<ATZBOrder>> GetAllOrderByUserIdAsync(string userId);
    }
}
