namespace ATZB.Services.ApplicationServices
{
    public interface IPasswordHasherService
    {
        (byte[] saltBytes, byte[] hashedPassword) HashPassword(string password);
    }
}
