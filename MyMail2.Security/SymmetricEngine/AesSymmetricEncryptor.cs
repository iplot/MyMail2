using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyMail2.Security.Helpers;

namespace MyMail2.Security.SymmetricEngine
{
    public class AesSymmetricEncryptor : ISymmetricEncryptor
    {
        private Aes _aesManager;

        public AesSymmetricEncryptor()
        {
            _aesManager = new AesManaged();
        }

        public byte[] Key
        {
            get { return _aesManager.Key; }
            set { _aesManager.Key = value; }
        }

        public byte[] IdentVector
        {
            get { return _aesManager.IV; }
            set { _aesManager.IV = value; }
        }

        public byte[] Encrypt(byte[] originalValue)
        {
            try
            {
                checkKeys();

                ICryptoTransform transform = _aesManager.CreateEncryptor();

                using (MemoryStream output = new MemoryStream())
                using (CryptoStream encrypt = new CryptoStream(output, transform, CryptoStreamMode.Write))
                using(BinaryWriter writer = new BinaryWriter(encrypt))
                {
                    writer.Write(originalValue);

                    writer.Flush();
                    encrypt.FlushFinalBlock();
                    return output.ToArray();
                }
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
                checkKeys();

                ICryptoTransform transform = _aesManager.CreateDecryptor();

                using (MemoryStream input = new MemoryStream(encryptedValue))
                using(CryptoStream decrypt = new CryptoStream(input, transform, CryptoStreamMode.Read))
                using(StreamReader reader = new StreamReader(decrypt))
                {
                    var originalStringValue = reader.ReadToEnd();

                    return StringByteConverter.GetStringBytes(originalStringValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkKeys()
        {
            if (_aesManager.Key == null || _aesManager.IV == null)
            {
                throw new Exception("Symmetric encryption keys missed");
            }
        }
    }
}
