using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Data.DataContext;
using ATZB.Domain;
using ATZB.Services.ApplicationServices;
using ATZB.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ATZB.Tests.ApplicationServices
{
    public class UserServiceTest
    {
        [Fact]
        public void GetAllUsersTest()
        {
            DbContextOptions<ATZBDbContext> options = new DbContextOptionsBuilder<ATZBDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            ATZBDbContext context = new ATZBDbContext(options);

            UserService userService = new UserService(context);

            SeedDbWithUsers(context ,DataForSeedUsers);

            int expectedUserCount = context.Users.Count();
            int actualUserCount = userService.GetAllUsersAsync().Result.Count;

            Assert.Equal(expectedUserCount, actualUserCount);
            
        }

        [Fact]
        public async Task CreateUserTest()
        {
            DbContextOptions<ATZBDbContext> options = new DbContextOptionsBuilder<ATZBDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            ATZBDbContext context = new ATZBDbContext(options);

            UserService userService = new UserService(context);

            int expectedUsersCount = context.Users.Count() + 1;

           await userService.CreateUserAsync(new ATZBUser());
           int actualUsersCount = context.Users.Count();

            Assert.Equal(expectedUsersCount,actualUsersCount);
        }

        //TODO: Rado check the test
        [Fact]
        public async Task GetUserByEmailAndPasswordTest()
        {
            DbContextOptions<ATZBDbContext> options = new DbContextOptionsBuilder<ATZBDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            ATZBDbContext context = new ATZBDbContext(options);
            UserService userService = new UserService(context);
            PasswordHasherService passwordHasherService = new PasswordHasherService();
            string emailForTest = "testmail1@test.bg";
            string passwordForTest = "testpassword1";
            var passwordHashed = await passwordHasherService.HashPasswordAsync(passwordForTest);


            ATZBUser expectedUser = new ATZBUser() {Email = emailForTest 
                ,PasswordHash = passwordHashed.Key 
                , PasswordSalt = passwordHashed.Value};
            SeedDbWithUsers(context, DataForSeedUsers);
            await userService.CreateUserAsync(expectedUser);

            var actualUser = userService.GetUserByUsernameAndPasswordAsync(emailForTest, passwordForTest).Result.Key;
            
            Assert.Equal(expectedUser , actualUser);
        }

        [Fact]
        public void TheEmailAlreadyExistTest()
        {
            DbContextOptions<ATZBDbContext> options = new DbContextOptionsBuilder<ATZBDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            ATZBDbContext context = new ATZBDbContext(options);

            UserService userService = new UserService(context);
            string emailForCheck = "test@abv.bg";
            SeedDbWithUsers(context , DataForSeedUsers);
           
            context.Users
                .AddRange(
                    new List<ATZBUser>()
                        {
                            new ATZBUser(){Email = emailForCheck} ,
                            new ATZBUser(){Email = emailForCheck}
                        });
            context.SaveChanges();


            Assert.True(userService.EmailAlreadyExistAsync(emailForCheck).Result);

        }

        public void SeedDbWithUsers(ATZBDbContext context, List<ATZBUser> users)
        {
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public List<ATZBUser> DataForSeedUsers => new List<ATZBUser>()
            { new ATZBUser(),new ATZBUser(), new ATZBUser(), new ATZBUser() , new ATZBUser(), new ATZBUser() , new ATZBUser(), new ATZBUser() , new ATZBUser(), new ATZBUser() };

    }
}
