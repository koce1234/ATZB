﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATZB.Services.BaseServices
{
    public class PasswordValidatorService : IPasswordValidatorService
    {
        public async Task<bool> CompareHashAsync(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb)
        {
            byte[] passwordBytes = UnicodeEncoding.Unicode.GetBytes(inputedPassword);

            byte[] combinedBytes = new byte[passwordBytes.Length + saltFromDb.Length];

            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(saltFromDb, 0, combinedBytes, passwordBytes.Length, saltFromDb.Length);

            HashAlgorithm hashAlgorithm = new SHA512Managed();
            byte[] hash = hashAlgorithm.ComputeHash(combinedBytes);

            byte[] hashPlusSalt = new byte[hash.Length + saltFromDb.Length];

            Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
            Buffer.BlockCopy(saltFromDb, 0, hashPlusSalt, hash.Length, saltFromDb.Length);

            var result = hashPlusSalt.SequenceEqual(passwordFromDb);

            if (hashPlusSalt.SequenceEqual(passwordFromDb))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
