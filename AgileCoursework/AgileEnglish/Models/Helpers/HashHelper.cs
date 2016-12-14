using System.Security.Cryptography;
using System.Text;

namespace AgileEnglish.Models.Helpers
{
    public static class HashHelper
    {
        public static string HashToSHA256(this string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}