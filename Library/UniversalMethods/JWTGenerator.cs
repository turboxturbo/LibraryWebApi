using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Models;
using Library.Requests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Library.UniversalMethods
{
    public class JWTGenerator
    {
        private readonly string _secretkey;
        public JWTGenerator(IConfiguration configuration) {
            _secretkey = configuration["JWT:Key"] ?? throw new Exception("JWT is not found");
        }
        public string GenerateToken(LoginPassword user)
        {
            var claims = new[] 
            {
                new Claim("userId", user.IdUser.ToString()),
                new Claim("roleId", user.IdRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                claims: claims, signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
