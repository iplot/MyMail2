using System;
using System.Security.Cryptography;

namespace MyMail2.Security.AsymmetricEngine
{
    public class RsaAsymmetricEncryptor : IRsaAsymmetricEncryptor
    {
        private readonly RSACryptoServiceProvider _rsaEncryptor;

        public RsaAsymmetricEncryptor()
        {
            _rsaEncryptor = new RSACryptoServiceProvider();
        }

        public byte[] RsaKeys
        {
            get { return _rsaEncryptor.ExportCspBlob(true); }
            set { _rsaEncryptor.ImportCspBlob(value); }
        }

        public byte[] Encrypt(byte[] originalValue)
        {
            try
            {
                keysCheck();

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
                keysCheck();

                return _rsaEncryptor.Decrypt(encryptedValue, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void keysCheck()
        {
            if (RsaKeys == null || RsaKeys.Length == 0)
            {
                throw new Exception("Asymmetric encryption keys missed");
            }
        }
    }
}