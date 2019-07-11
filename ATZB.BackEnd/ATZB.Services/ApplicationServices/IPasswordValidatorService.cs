namespace ATZB.Services.ApplicationServices
{
    using System.Threading.Tasks;

    public interface IPasswordValidatorService
    {
        Task<bool> CompareHash(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb);
    }
}
