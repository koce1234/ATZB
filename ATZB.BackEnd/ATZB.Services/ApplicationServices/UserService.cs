using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Data;
using ATZB.Domain;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Services.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly ATZBDbContext _DbContext;
        private readonly IPasswordValidatorService _PasswordValidator;
        private readonly ITokenGeneratorService _TokenGeneratorService;

        public UserService(ATZBDbContext dbContext
            ,IPasswordValidatorService passwordValidator
            ,ITokenGeneratorService tokenGeneratorService)
        {
            _DbContext = dbContext;
            _PasswordValidator = passwordValidator;
            _TokenGeneratorService = tokenGeneratorService;
        }

        public async Task<ATZBUser> CreateUser(ATZBUser user)
        {
            //user = await _DbContext.Users.AddAsync(user).Entity;       Kakvo pravush tuka Koce
            await _DbContext.Users.AddAsync(user);
            await _DbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<ATZBUser>> GetAllUsers()
        {
            var users = await _DbContext.Users.ToListAsync();
            return users;
        }

        public async Task<KeyValuePair<ATZBUser,string>> GetUserByUsernameAndPassword(string email, string password)
        {
            
            var user = await _DbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null,string.Empty);
                return keyValue;
            }

            var validatePassword = await _PasswordValidator
               .CompareHash(password, user.PasswordHash, user.PasswordSalt);

            if (validatePassword)
            {
                var token = await _TokenGeneratorService.GenerateJWT(user.Id, user.Email);
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(user, token);
                return keyValue;

            }
            else
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null, string.Empty);
                return keyValue;
            }
        }

        public async Task<bool> EmailAlreadyExist(string email) => await _DbContext.Users.AnyAsync(x => x.Email == email);
    }
}
