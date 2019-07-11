using System.Collections.Generic;
using System.Linq;
using ATZB.Data;
using ATZB.Domain;

namespace ATZB.Services.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly ATZBDbContext _DbContext;
        private readonly IPasswordValidatorService _PasswordValidator;
        private readonly ITokenGeneratorService _TokenGeneratorService;

        public UserService(ATZBDbContext _dbContext
            ,IPasswordValidatorService _passwordValidator
            ,ITokenGeneratorService _tokenGeneratorService)
        {
            _DbContext = _dbContext;
            _PasswordValidator = _passwordValidator;
            _TokenGeneratorService = _tokenGeneratorService;
        }

        public ATZBUser CreateUser(ATZBUser user)
        {
            user = this._DbContext.Users.Add(user).Entity;
            this._DbContext.SaveChanges();

            return user;
        }

        public  List<ATZBUser> GetAllUsers()
        {
            var users = this._DbContext.Users.ToList();
            return users;
        }

        public KeyValuePair<ATZBUser,string> GetUserByUsernameAndPassword(string email, string password)
        {
            
            var user = _DbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null,string.Empty);
                return keyValue;
            }
            var validatePassword = _PasswordValidator
               .CompareHash(password, user.PasswordHash, user.PasswordSalt);
            if (validatePassword)
            {
                var token = _TokenGeneratorService.GenerateJWT(user.Id, user.Email);
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(user, token);
                return keyValue;

            }
            else
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null, string.Empty);
                return keyValue;
            }
        }

        public bool EmailAlreadyExist(string email) => _DbContext.Users.Any(x => x.Email == email);
    }
}
