using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace EstoqueMangas.Core.Extensions
{
    public static class StringExtension
    {
        public static string ToHash(this string texto)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
            {
                hashBytes = hash.ComputeHash(encoding.GetBytes(texto));
            }

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }
    }
}
