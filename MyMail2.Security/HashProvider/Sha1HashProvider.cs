using System;
using System.Security.Cryptography;

namespace MyMail2.Security.HashProvider
{
    public class Sha1HashProvider : IHashProvider
    {
        public byte[] GetHash(byte[] data)
        {
            try
            {
                using (SHA1CryptoServiceProvider hashProvider = new SHA1CryptoServiceProvider())
                {
                    return hashProvider.ComputeHash(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO Choose a better name
        public object CreateHashProviderObject { get { return new SHA1CryptoServiceProvider(); } }
    }
}