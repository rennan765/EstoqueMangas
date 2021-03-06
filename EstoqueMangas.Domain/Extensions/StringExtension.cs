﻿using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace EstoqueMangas.Domain.Extensions
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

        public static bool IsNumeric(this string texto)
        {
            bool isnumeric = false;
            char[] datachars = texto.ToCharArray();

            foreach (var datachar in datachars)
            {
                isnumeric = char.IsDigit(datachar);
                    
                if (!isnumeric)
                {
                    break;
                }
            }
                
            return isnumeric;
        }

        public static int ToInt(this string texto)
        {
            return Convert.ToInt32(texto);
        }

        public static bool ValidateLength(this string texto, int minLength, int maxLength)
        {
            return texto.Length >= minLength && texto.Length <= maxLength;
        }
    }
}
