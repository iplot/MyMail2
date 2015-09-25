using System;
using System.Collections.Generic;
using System.Linq;
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
            _encryptor = new SymmetricEncryptor();
        }

        [Test]
        public void EncryptAndDescriptStringTest()
        {
            //Arrange
            string test_val = "Test string";
            
            //Act
            byte[] encrypt = _encryptor.Encrypt(Encoding.UTF8.GetBytes(test_val));
            byte[] result = _encryptor.Decrypt(encrypt);

            string str = StringByteConverter.GetStringFromBytes(result);

            //Assert
            Assert.AreEqual(test_val, str);
        }
    }
}
