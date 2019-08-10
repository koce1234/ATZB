namespace ATZB.Services.ApplicationServices
{
    using ATZB.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
<<<<<<< HEAD
        Task<ATZBUser> CreateUser(ATZBUser user);

        Task<KeyValuePair<ATZBUser, string>> GetUserByUsernameAndPassword(string email, string password);

        Task<List<ATZBUser>> GetAllUsers();

