using System.Threading.Tasks;

namespace ATZB.Services.BaseServices
{
    public interface ITokenGeneratorService
    {
        Task<string> GenerateJWT(string id, string email);
    }
}
