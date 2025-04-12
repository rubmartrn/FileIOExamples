using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi
{
    public class TokenGenerator
    {
        public string Generate(string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "sidushoaslkaosdosadjoijsaoisaiojdsdfhjfidushfuisdhfuisdf";
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub.ToString(), email),
                new Claim("usertype", "student"),
                new Claim("role", role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "http://AuthApi.am",
                Audience = "http://BankApi.am",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
