using API.ApplicationConstants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Utilities
{
    public class TokenHelper
    {
        public static async Task<string> GenerateAccessTokenAsync(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(Constants.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            var claimsIdentity=new ClaimsIdentity(claims);

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Constants.Issuer,
                Audience = Constants.Audience,
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddMinutes(5)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(tokenHandler.WriteToken(securityToken));
        }

        public static async Task<string> GenerateRefreshToken()
        {
            var bytes = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);

            var refreshToken = Convert.ToBase64String(bytes);

            return await Task.FromResult(refreshToken);

        }
    }
}
