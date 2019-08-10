namespace ATZB.Services.ApplicationServices
{
    using ATZB.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
<<<<<<< .merge_file_a14784
        Task<ATZBUser> CreateUser(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByUsernameAndPassword(string email, string password);

        Task<List<ATZBUser>> GetAllUsers();

        Task<bool> EmailAlreadyExist(string email);
=======
        Task<ATZBUser> CreateUserAsync(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByEmailAndPasswordAsync(string email, string password);

        Task<List<ATZBUser>> GetAllUsersAsync();

        Task<bool> EmailAlreadyExistAsync(string email);
>>>>>>> .merge_file_a13136
    }
}
