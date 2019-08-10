using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Data.DataContext;
using ATZB.Domain;
using ATZB.Services.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Services.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordValidatorService _passwordValidator;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public UserService(ATZBDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public UserService(ATZBDbContext dbContext
            ,IPasswordValidatorService passwordValidator
            ,ITokenGeneratorService tokenGeneratorService)
        {
            _dbContext = dbContext;
            _passwordValidator = passwordValidator;
            _tokenGeneratorService = tokenGeneratorService;
        }

        public async Task<ATZBUser> CreateUser(ATZBUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<ATZBUser>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<KeyValuePair<ATZBUser, string>> GetUserByUsernameAndPassword(string email, string password)
        {
            
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null,string.Empty);
                return keyValue;
            }

            var validatePassword =  _passwordValidator
                .CompareHashAsync(password , user.PasswordHash , user.PasswordSalt).Result;

            if (validatePassword)
            {
                var token = await _tokenGeneratorService.GenerateJWT(user.Id, user.Email);
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(user, token);
                return keyValue;

            }
            else
            {
               KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null, string.Empty);
                return keyValue;
            }
        }

        public async Task<bool> EmailAlreadyExist(string email) 
            => await _dbContext.Users.AnyAsync(x => x.Email == email);
    }
}
