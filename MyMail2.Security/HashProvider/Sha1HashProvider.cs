using System;
using System.Security.Cryptography;

namespace MyMail2.Security.HashProvider
{
    public class Sha1HashProvider : IHashProvider
    {
        private string _name = "SHA1";

        public string AlgName { 
            get { return _name; }
        }

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
    }
}