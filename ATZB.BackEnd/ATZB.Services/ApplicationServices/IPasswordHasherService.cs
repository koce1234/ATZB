namespace ATZB.Services.ApplicationServices
{
    using System.Collections.Generic;

    public interface IPasswordHasherService
    {
        KeyValuePair<byte[], byte[]> HashPassword(string password);
    }
}
