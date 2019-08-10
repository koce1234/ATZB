using System.Collections.Generic;
using System.Threading.Tasks;
using ATZB.Data;
using ATZB.Data.DataContext;
using ATZB.Domain;
<<<<<<< .merge_file_a04452
=======
using ATZB.Services.BaseServices;
>>>>>>> .merge_file_a12004
using Microsoft.EntityFrameworkCore;

namespace ATZB.Services.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly ATZBDbContext _dbContext;
        private readonly IPasswordValidatorService _passwordValidator;
        private readonly ITokenGeneratorService _tokenGeneratorService;

<<<<<<< .merge_file_a04452
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
=======
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

        public async Task<ATZBUser> CreateUserAsync(ATZBUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
>>>>>>> .merge_file_a12004

            return user;
        }

<<<<<<< .merge_file_a04452
        public async Task<List<ATZBUser>> GetAllUsers()
        {
            var users = await _DbContext.Users.ToListAsync();
            return users;
        }

        public async Task<KeyValuePair<ATZBUser,string>> GetUserByUsernameAndPassword(string email, string password)
        {
            
            var user = await _DbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
=======
        public async Task<List<ATZBUser>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<KeyValuePair<ATZBUser,string>> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
>>>>>>> .merge_file_a12004

            if (user == null)
            {
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null,string.Empty);
                return keyValue;
            }

<<<<<<< .merge_file_a04452
            var validatePassword = await _PasswordValidator
               .CompareHash(password, user.PasswordHash, user.PasswordSalt);

            if (validatePassword)
            {
                var token = await _TokenGeneratorService.GenerateJWT(user.Id, user.Email);
=======
            var validatePassword =  _passwordValidator
               .CompareHashAsync(password , user.PasswordHash , user.PasswordSalt).Result;

            if (validatePassword)
            {
                var token = await _tokenGeneratorService.GenerateJWTAsync(user.Id, user.Email);
>>>>>>> .merge_file_a12004
                KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(user, token);
                return keyValue;

            }
            else
            {
               KeyValuePair<ATZBUser, string> keyValue = new KeyValuePair<ATZBUser, string>(null, string.Empty);
                return keyValue;
            }
        }

<<<<<<< .merge_file_a04452
        public async Task<bool> EmailAlreadyExist(string email) => await _DbContext.Users.AnyAsync(x => x.Email == email);
=======
        public async Task<bool> EmailAlreadyExistAsync(string email) 
            => await _dbContext.Users.AnyAsync(x => x.Email == email);
>>>>>>> .merge_file_a12004
    }
}
