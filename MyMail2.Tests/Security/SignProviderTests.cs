using System;
using System.Security.Cryptography;
using System.Text;
using MyMail2.Security.HashProvider;
using MyMail2.Security.SignEngine;
using NUnit.Framework;

namespace MyMail2.Tests.Security
{
    [TestFixture]
    public class SignProviderTests
    {
        private ISignProvider _signProvider;

        public SignProviderTests()
        {
            _signProvider = new RsaSignProvider(new Sha1HashProvider());
        }

        [SetUp]
        public void Init()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            _signProvider.Keys = rsa.ExportCspBlob(true);
        }

        [TestCase("Test string", Result = true)]
        [TestCase("", Result = true)]
        public bool SignAndVerifyString(string str)
        {
            //Arrange
            var test_data = Encoding.UTF8.GetBytes(str);

            //Act
            var sign = _signProvider.SignData(test_data);

            //Assert
            return _signProvider.VerifySign(test_data, sign);
        }

        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new Byte[0], ExpectedException = typeof(IndexOutOfRangeException))]
        public void SignWithoutKeys(byte[] key)
        {
            //Arrange
            _signProvider.Keys = key;
            string str = "Test string";
            var test_data = Encoding.UTF8.GetBytes(str);

            //Act
            //Assert
            var sign = _signProvider.SignData(test_data);
        }
    }
}