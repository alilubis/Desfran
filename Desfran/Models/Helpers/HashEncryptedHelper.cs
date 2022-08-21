using System.Text;
using System.Security.Cryptography;

namespace Desfran.Models.Helpers
{
    public static class HashEncryptedHelper
    {
        public static string HashPassword(string password)
        {
            var passwordArray = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(passwordArray);
            var hashPassword = new StringBuilder(hash.Length);
            foreach (byte b in hash)
            {
                hashPassword.Append(b.ToString());
            }
            return hashPassword.ToString();
        }
    }
}
