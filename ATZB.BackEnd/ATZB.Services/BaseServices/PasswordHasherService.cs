<<<<<<< HEAD:ATZB.BackEnd/ATZB.Services/ApplicationServices/PasswordHasherService.cs
﻿namespace ATZB.Services.ApplicationServices
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 7c8e6dfe4cd09429b90c592825533f30bbe57113:ATZB.BackEnd/ATZB.Services/BaseServices/PasswordHasherService.cs

namespace ATZB.Services.BaseServices
{
    public class PasswordHasherService : IPasswordHasherService
    {
<<<<<<< HEAD:ATZB.BackEnd/ATZB.Services/ApplicationServices/PasswordHasherService.cs
        public async Task<KeyValuePair<byte[], byte[]>> HashPassword(string password)
=======
        public async Task<KeyValuePair<byte[], byte[]>> HashPasswordAsync(string password)
>>>>>>> 7c8e6dfe4cd09429b90c592825533f30bbe57113:ATZB.BackEnd/ATZB.Services/BaseServices/PasswordHasherService.cs
        {
            byte[] salt = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(salt);

            byte[] passwordBytes = UnicodeEncoding.Unicode.GetBytes(password);

            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];

            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            HashAlgorithm hashAlgorithm = new SHA512Managed();
            byte[] hash = hashAlgorithm.ComputeHash(combinedBytes);

            byte[] hashPlusSalt = new byte[hash.Length + salt.Length];

            Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
            Buffer.BlockCopy(salt, 0, hashPlusSalt, hash.Length, salt.Length);

            return new KeyValuePair<byte[], byte[]>(hashPlusSalt, salt);
        }
    }
}
