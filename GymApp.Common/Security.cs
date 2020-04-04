﻿using System;
using System.Security.Cryptography;
using System.Text;


namespace GymApp.Common
{
    public static class Security
    {
        public static string HashPassword(string plainTextPass)
        {
            using (var algorithm = new MD5CryptoServiceProvider())
            {
                var inputBytes = Encoding.UTF8.GetBytes(plainTextPass);
                var hashedBytes = algorithm.ComputeHash(inputBytes);
                return BitConverter.ToString(hashedBytes); //.Replace("-", "");
            }
        }

        public static string HashPassword(string plainTextPass, string salt)
        {
            plainTextPass = string.Format("{0}{1}{0}", salt, plainTextPass);
            using (var algorithm = new SHA1Managed())
            {
                var inputBytes = Encoding.UTF8.GetBytes(plainTextPass);
                var hashedBytes = algorithm.ComputeHash(inputBytes);
                return BitConverter.ToString(hashedBytes); //.Replace("-", "");
            }
        }
    }
}
