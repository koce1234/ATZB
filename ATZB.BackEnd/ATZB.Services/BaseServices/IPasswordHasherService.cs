using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATZB.Services.BaseServices
{
    public interface IPasswordHasherService
    {
        Task<KeyValuePair<byte[], byte[]>> HashPasswordAsync(string password);
    }
}
