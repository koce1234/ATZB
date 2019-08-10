namespace ATZB.Services.ApplicationServices
{
    using ATZB.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<ATZBUser> CreateUser(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByUsernameAndPassword(string email, string password);

        Task<List<ATZBUser>> GetAllUsers();

        Task<bool> EmailAlreadyExist(string email);
    }
}

