<<<<<<< HEAD:ATZB.BackEnd/ATZB.Services/ApplicationServices/PasswordValidatorService.cs
﻿namespace ATZB.Services.ApplicationServices
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
=======
﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 7c8e6dfe4cd09429b90c592825533f30bbe57113:ATZB.BackEnd/ATZB.Services/BaseServices/PasswordValidatorService.cs

namespace ATZB.Services.BaseServices
{
    public class PasswordValidatorService : IPasswordValidatorService
    {
<<<<<<< HEAD:ATZB.BackEnd/ATZB.Services/ApplicationServices/PasswordValidatorService.cs
        public async Task<bool> CompareHash(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb)
=======
        public async Task<bool> CompareHashAsync(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb)
>>>>>>> 7c8e6dfe4cd09429b90c592825533f30bbe57113:ATZB.BackEnd/ATZB.Services/BaseServices/PasswordValidatorService.cs
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
