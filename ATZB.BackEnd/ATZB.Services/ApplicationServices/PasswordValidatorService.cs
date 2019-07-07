namespace ATZB.Services.ApplicationServices
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordValidatorService : IPasswordValidatorService
    {
        public bool CompareHash(string inputedPassword, byte[] passwordFromDb, byte[] saltFromDb)
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
