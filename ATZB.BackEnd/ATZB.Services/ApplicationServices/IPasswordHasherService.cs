namespace ATZB.Services.ApplicationServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPasswordHasherService
    {
        Task<KeyValuePair<byte[], byte[]>> HashPassword(string password);
    }
}
