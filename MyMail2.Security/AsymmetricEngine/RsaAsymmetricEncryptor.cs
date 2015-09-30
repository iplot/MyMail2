using System;
using System.Security.Cryptography;

namespace MyMail2.Security.AsymmetricEngine
{
    //TODO Create exception for Key = byte[0]

    public class RsaAsymmetricEncryptor : IAsymmetricEncryptor
    {
        private readonly RSACryptoServiceProvider _rsaEncryptor;

        public RsaAsymmetricEncryptor()
        {
            _rsaEncryptor = new RSACryptoServiceProvider();
        }

        //null -> ArgumentNullException
        //byte[0] -> IndexOutOfRangeException
        public byte[] RsaKeys
        {
            get { return _rsaEncryptor.ExportCspBlob(true); }
            set { _rsaEncryptor.ImportCspBlob(value); }
        }

        public byte[] Encrypt(byte[] originalValue)
        {
            try
            {
                return _rsaEncryptor.Encrypt(originalValue, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] Decrypt(byte[] encryptedValue)
        {
            try
            {
                return _rsaEncryptor.Decrypt(encryptedValue, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}