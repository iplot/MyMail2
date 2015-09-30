using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyMail2.Security.Helpers;
using MyMail2.Security.SymmetricEngine;
using NUnit.Framework;

namespace MyMail2.Tests.Security
{
    [TestFixture]
    public class SymmetricEncryptorTests
    {
        private ISymmetricEncryptor _encryptor;

        public SymmetricEncryptorTests()
        {
            _encryptor = new AesSymmetricEncryptor();
        }

        [SetUp]
        public void Init()
        {
            AesManaged aes = new AesManaged();
            _encryptor.Key = aes.Key;
            _encryptor.IdentVector = aes.IV;
        }

        [TestCase("Test string", Result = "Test string")]
        [TestCase("", Result = "")]

        public string EncryptAndDescriptStringTest(string test_val)
        {
            //Act
            byte[] encrypt = _encryptor.Encrypt(Encoding.UTF8.GetBytes(test_val));
            byte[] result = _encryptor.Decrypt(encrypt);

            string str = StringByteConverter.GetStringFromBytes(result);

            //Assert
            return str;
        }

        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new Byte[0], ExpectedException = typeof(CryptographicException))]
        public void EncryptorWithoutKey(byte[] key)
        {
            //Arrange
            _encryptor.Key = key;
            string test_val = "Test string";

            //Assert
            Assert.Throws<Exception>(() => _encryptor.Encrypt(Encoding.UTF8.GetBytes(test_val)));
        }

        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new Byte[0], ExpectedException = typeof(CryptographicException))]
        public void EncryptorWithoutVector(byte[] vector)
        {
            //Arrange
            _encryptor.IdentVector = vector;
            string test_val = "Test string";

            //Assert
            Assert.Throws<Exception>(() => _encryptor.Encrypt(Encoding.UTF8.GetBytes(test_val)));
        }
    }
}
