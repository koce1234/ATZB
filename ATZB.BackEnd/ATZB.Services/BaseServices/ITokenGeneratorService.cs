using System.Threading.Tasks;

namespace ATZB.Services.BaseServices
{
    public interface ITokenGeneratorService
    {
        Task<string> GenerateJWTAsync(string id, string email);
    }
}
