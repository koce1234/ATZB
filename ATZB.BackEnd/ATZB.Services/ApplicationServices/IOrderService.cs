using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Domain;

namespace ATZB.Services.ApplicationServices
{
    public interface IOrderService
    {
        Task<List<ATZBOrder>> GetAllOrdersAsync();
    }
}
