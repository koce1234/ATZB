namespace ATZB.Services.ApplicationServices
{
    public interface ITokenGeneratorService
    {
        string GenerateJWT(string id, string email);
    }
}
