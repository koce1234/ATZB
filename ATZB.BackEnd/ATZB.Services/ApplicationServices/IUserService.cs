namespace ATZB.Services.ApplicationServices
{
    using ATZB.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<ATZBUser> CreateUserAsync(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByEmailAndPasswordAsync(string email, string password);

        Task<List<ATZBUser>> GetAllUsersAsync();

        Task<bool> EmailAlreadyExistAsync(string email);
    }
}
