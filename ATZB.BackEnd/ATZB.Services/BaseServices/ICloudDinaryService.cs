using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ATZB.Services.BaseServices
{
    public interface ICloudDinaryService
    {
        Task<string> CreateImageAsync(IFormFile formFile, string fileName);
    }
}
