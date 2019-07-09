using ATZB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Services.ApplicationServices
{
    public interface IUserService
    {
        ATZBUser CreateUser(ATZBUser user);

        KeyValuePair<ATZBUser, string> GetUserByUsernameAndPassword(string email, string password);

        List<ATZBUser> GetAllUsers();

        bool EmailAlreadyExist(string email);
    }
}
