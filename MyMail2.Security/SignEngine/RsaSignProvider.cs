using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyMail2.Security.HashProvider;

namespace MyMail2.Security.SignEngine
{
    public class RsaSignProvider : ISignProvider
    {
        private readonly IHashProvider _hashProvider;
        private readonly RSACryptoServiceProvider _signProvider;

        public RsaSignProvider(IHashProvider provider)
        {
            _hashProvider = provider;
            _signProvider = new RSACryptoServiceProvider();
        }

        public byte[] Keys
        {
            get { return _signProvider.ExportCspBlob(true); }
            set { _signProvider.ImportCspBlob(value);}
        }

        public byte[] SignData(byte[] data)
        {
            try
            {
                var hash = _hashProvider.GetHash(data);

                return _signProvider.SignHash(hash, CryptoConfig.MapNameToOID(_hashProvider.AlgName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerifySign(byte[] data, byte[] signature)
        {
            try
            {
                var hash = _hashProvider.GetHash(data);

                return _signProvider.VerifyHash(hash, CryptoConfig.MapNameToOID(_hashProvider.AlgName), signature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
