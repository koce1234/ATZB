namespace ATZB.Services.ApplicationServices
{
    using System.Threading.Tasks;

    public interface ITokenGeneratorService
    {
        Task<string> GenerateJWT(string id, string email);
    }
}
