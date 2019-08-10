using ATZB.Services.BaseServices;

namespace ATZB.Services.ApplicationServices
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using System.Security.Claims;
    using System;
    using System.Threading.Tasks;

    public class TokenGeneratorService : ITokenGeneratorService
    {
        public IConfiguration _configuration;

        public TokenGeneratorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


<<<<<<< HEAD:ATZB.BackEnd/ATZB.Services/ApplicationServices/TokenGeneratorService.cs
        public async Task<string> GenerateJWT(string id, string email)
=======
        public async Task<string> GenerateJWTAsync(string id, string email)
>>>>>>> 7c8e6dfe4cd09429b90c592825533f30bbe57113:ATZB.BackEnd/ATZB.Services/BaseServices/TokenGeneratorService.cs
        {
            string securityKey = _configuration.GetSection("SecurityKey").Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKeyToBytes = Encoding.ASCII.GetBytes(securityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "standartUser",
                Issuer = "smesk.in",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKeyToBytes),
                                        SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenToSting = tokenHandler.WriteToken(token);

            return tokenToSting;
        }
    }
}
