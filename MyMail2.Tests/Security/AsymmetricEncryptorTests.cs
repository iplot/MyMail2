using System;
using System.Security.Cryptography;
using System.Text;
using MyMail2.Security.AsymmetricEngine;
using MyMail2.Security.Helpers;
using NUnit.Framework;

namespace MyMail2.Tests.Security
{
    [TestFixture]
    public class AsymmetricEncryptorTests
    {
        private IAsymmetricEncryptor _encryptor;

        public AsymmetricEncryptorTests()
        {
            _encryptor = new RsaAsymmetricEncryptor();
        }

        [SetUp]
        public void Init()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            _encryptor.RsaKeys = rsa.ExportCspBlob(true);
        }

        [TestCase("Test string", Result = "Test string")]
        [TestCase("", Result = "")]
        public string EncryptAndDecryptString(string str)
        {
            //Act
            var encData = _encryptor.Encrypt(Encoding.UTF8.GetBytes(str));
            var resDataBytes = _encryptor.Decrypt(encData);

            string res_str = Encoding.UTF8.GetString(resDataBytes);

            //Assert
            return res_str;
        }

        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new Byte[0], ExpectedException = typeof(IndexOutOfRangeException))]
        public void EncryptWithoutKeys(byte[] key)
        {
            //Arrange
            _encryptor.RsaKeys = key;
            var test_data = Encoding.UTF8.GetBytes("Test string");

            //Act
            //Assert
            _encryptor.Encrypt(test_data);
        }
    }
}