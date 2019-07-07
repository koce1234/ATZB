namespace ATZB.Services.ApplicationServices
{
    public interface IPasswordValidatorService
    {
        bool CompareHash(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb);
    }
}
