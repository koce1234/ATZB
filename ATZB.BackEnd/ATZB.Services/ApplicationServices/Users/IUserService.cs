namespace ATZB.Services.ApplicationServices.Users
{
    using ATZB.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<ATZBUser> CreateUserAsync(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByUsernameAndPasswordAsync(string email, string password);

        Task<List<ATZBUser>> GetAllUsersAsync();

        Task<bool> EmailAlreadyExistAsync(string email);
    }
}

