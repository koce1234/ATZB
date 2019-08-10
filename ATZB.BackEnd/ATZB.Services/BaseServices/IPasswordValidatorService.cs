using System.Threading.Tasks;

namespace ATZB.Services.BaseServices
{
    public interface IPasswordValidatorService
    {
        Task<bool> CompareHashAsync(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb);
    }
}
