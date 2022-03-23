using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace API.Utilities
{
    public class PasswordHelper
    {
        public static byte[] RenderSecureSalt()
        {
            return RandomNumberGenerator.GetBytes(32);
        }

        public static string CreatePasswordHash(string password, byte[] salt)
        {
            var derivedKey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100000, 32);

            return Convert.ToBase64String(derivedKey);
        }
    }
}
