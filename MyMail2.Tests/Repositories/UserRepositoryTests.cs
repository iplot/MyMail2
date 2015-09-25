using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Repositories;
using NUnit.Framework;

namespace MyMail2.Tests.Repositories
{
    [TestFixture]
    class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepositoryTests()
        {
            DbContext context = new MyMailDataContext();

            IDbContextFactory factory = new DbContextFactory(context);

            _userRepository = new UserRepository(factory);
            _unitOfWork = new UnitOfWork(factory);
        }

        [Test]
        [Ignore]
        public void Add()
        {
            //Arrange
            var user1 = new User
            {
                BirthDate = DateTime.Now,
                City = "Donetsk",
                Country = "Ukraine",
                FirstName = "Dave",
                IdentVector = "Vector",
                WorkPlace = "Home"
            };

            //Act
            _userRepository.Add(user1);
            _unitOfWork.SaveChanges();
        }

        [Test]
        public void GetUserById()
        {
            //Arrange
            //Act
            var user = _userRepository.Get(1);

            //Assert
            Assert.AreEqual("Dave", user.FirstName);
        }

        [Test]
        [Ignore]
        public void GetAllUsers()
        {
            //Arrange
            //Act
            var users = _userRepository.GetAll();

            //Assert
            Assert.AreEqual(1, users.Count());
        }

        [Test]
        [Ignore]
        public void UpdateUser()
        {
            //Arrange
            var user = _userRepository.Get(1);
            user.City = "Kiyv";

            //Act
            _userRepository.Update(user);
            _unitOfWork.SaveChanges();

            //Assert
            var n_user = _userRepository.Get(1);
            Assert.AreEqual("Kiyv", n_user.City);
        }
    }
}
