namespace ATZB.Services.ApplicationServices
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHasherService : IPasswordHasherService
    {
        public (byte[] saltBytes, byte[] hashedPassword) HashPassword(string password)
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

            return (salt, hashPlusSalt);
        }
    }
}
