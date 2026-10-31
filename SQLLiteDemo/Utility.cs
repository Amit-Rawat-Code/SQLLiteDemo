using System.Security.Cryptography;
using System.Text;

namespace SQLLiteDemo
{
    public static class Utility
    {
        public static string Hash(string password)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = Hash(inputPassword);
            return inputHash == storedHash;
        }

    }
}
