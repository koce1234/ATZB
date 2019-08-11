using ATZB.Data.DataContext;
using ATZB.Services.BaseServices;

namespace ATZB.Web
{
    using ATZB.Data;
    using ATZB.Services.ApplicationServices;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string securityKey = _configuration.GetSection("SecurityKey").Value;
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            services.AddDbContext<ATZBDbContext>(options =>
                options
                .UseSqlServer(_configuration.GetSection("DbConnectionString").Value));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "smesk.in",
                            ValidAudience = "standartUser",
                            IssuerSigningKey = symetricSecurityKey
                        });

            services.AddTransient<ITokenGeneratorService, TokenGeneratorService>();
            services.AddTransient<IPasswordHasherService, PasswordHasherService>();
            services.AddTransient<IPasswordValidatorService, PasswordValidatorService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}