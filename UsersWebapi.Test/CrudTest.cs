using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UsersWebapi.Controllers;
using UsersWebapi.Data.Interfaces;
using UsersWebapi.Data.Models;

namespace UsersWebapi.Test
{
    [TestClass]
    public class CrudTest
    {
        List<User> expectedUsers;
        Mock<IUserRepository> mockUserRepository;
        UsersController usersController;

        [TestInitialize]
        public void InitializeTestData()
        {
            //Datos de prueba
            expectedUsers = GetExpectedUsers();
            //Arrange
            mockUserRepository = new Mock<IUserRepository>();
            usersController = new UsersController(mockUserRepository.Object);
            //Setup
            mockUserRepository.Setup(m => m.RetrieveAll()).Returns(expectedUsers);

            mockUserRepository.Setup(m => m.Create(It.IsAny<User>())).Returns(
                (User target) =>
                {
                    expectedUsers.Add(target);

                    return true;
                });

            mockUserRepository.Setup(m => m.Update(It.IsAny<User>())).Returns(
               (User target) =>
               {
                   User user = expectedUsers.Where(p => p.id == target.id).FirstOrDefault();

                   if (user == null)
                   {
                       return false;
                   }

                   user.Name = target.Name;
                   user.LastName = target.LastName;
                   user.Address = target.Address;
                   user.CreateDate = target.CreateDate;
                   user.UpdateDate = DateTime.Now;

                   return true;
               });

            mockUserRepository.Setup(m => m.Delete(It.IsAny<int>())).Returns(
               (int UserId) =>
               {
                   var user = expectedUsers.Where(p => p.id == UserId).FirstOrDefault();

                   if (user == null)
                   {
                       return false;
                   }

                   expectedUsers.Remove(user);

                   return true;
               });

        }

        [TestMethod]
        public void Get_All_Products()
        {
            //Act
            var actualUsers = mockUserRepository.Object.RetrieveAll();

            //Assert
            Assert.AreSame(expectedUsers, actualUsers);
        }
        [TestMethod]
        public void Add_Product()
        {
            int userCount = mockUserRepository.Object.RetrieveAll().Count;

            Assert.AreEqual(5, userCount);

            //Prepare
            User newUser = new User();
            //Act
            mockUserRepository.Object.Create(newUser);

            userCount = mockUserRepository.Object.RetrieveAll().Count;

            //Assert
            Assert.AreEqual(6, userCount);
        }
        [TestMethod]
        public void Update_Product()
        {
            User user = new User()
            {
                id = 5,
                Name = "Quintus",
                LastName = "Novus",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            mockUserRepository.Object.Update(user);

            // Verify the change
            Assert.AreEqual("Quintus", mockUserRepository.Object.RetrieveAll()[4].Name);
        }
        [TestMethod]
        public void Delete_Product()
        {
            Assert.AreEqual(5, mockUserRepository.Object.RetrieveAll().Count);

            mockUserRepository.Object.Delete(1);

            // Verify the change
            Assert.AreEqual(4, mockUserRepository.Object.RetrieveAll().Count);
        }

        [TestCleanup]
        public void CleanUpTestData()
        {
            expectedUsers = null;
            mockUserRepository = null;
        }

        // Helpers
        private static List<User> GetExpectedUsers()
        {
            // Datos de prueba
            return new List<User>()
            {
                new User{ id=1, Name="Aurora", LastName="Albornoz", Address="Calle 1 # 1-1", CreateDate=new DateTime(2019, 08, 01, 12, 30, 00), UpdateDate=DateTime.Now},
                new User{ id=2, Name="Benjamín", LastName="Buitrago", Address="Calle 2 # 2-2", CreateDate=new DateTime(2019, 08, 02, 12, 30, 00), UpdateDate=DateTime.Now},
                new User{ id=3, Name="Carolina", LastName="Carrillo", Address="Calle 3 # 3-3", CreateDate=new DateTime(2019, 08, 03, 12, 30, 00), UpdateDate=DateTime.Now},
                new User{ id=4, Name="Daniel", LastName="Duarte", Address="Calle 4 # 4-4", CreateDate=new DateTime(2019, 08, 04, 12, 30, 00), UpdateDate=DateTime.Now},
                new User{ id=5, Name="Eduardo", LastName="Echeverry", Address="Calle 5 # 5-5", CreateDate=new DateTime(2019, 08, 05, 12, 30, 00), UpdateDate=DateTime.Now}
            };

        }
    }
}
