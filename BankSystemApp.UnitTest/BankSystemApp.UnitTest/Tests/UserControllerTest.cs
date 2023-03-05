using BankSystemApp.Controllers;
using BankSystemApp.Interfaces;
using BankSystemApp.UnitTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BankSystemApp.Models;
using Xunit;

namespace BankSystemApp.UnitTest.Tests
{
    public class UserControllerTest
    {
        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void GetTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);

            //Act
            var lstModel = await userController.Get();

            //Assert
            Assert.True(lstModel != null);
        }
        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void GetNULLTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            List<UserAccountModel> userAccountModels = null;
            userAccountService.Setup(s => s.GetAllUserAccount()).Returns(Task.FromResult(userAccountModels));

            //Act
            var lstModel = await userController.Get();

            //Assert
            Assert.True(lstModel != null);
        }
        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void PostTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            var lstModel = await userController.Post(userModel);

            //Assert
            Assert.True(lstModel != null);
        }
        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void PUTTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            int id = 1;
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            var actionResult = await userController.Put(id,userModel);

            //Assert
            Assert.True(actionResult != null);
        }

        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void DepositTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            int id = 1;
            int amount = 250;

            //Act
            var actionResult = await userController.Deposit(id, amount);

            //Assert
            Assert.True(actionResult != null);
        }

        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void WithdrawTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            int id = 2;
            int amount = 1500;

            //Act
            var actionResult = await userController.Withdraw(id, amount);

            //Assert
            Assert.True(actionResult != null);
        }
        [Theory]
        [ClassData(typeof(UserControllerMock))]
        public async void DeleteTest(Mock<IUserAccountService> userAccountService)
        {
            //Arrange
            var userController = new UserController(userAccountService.Object);
            int id = 2;

            //Act
            var actionResult = await userController.Delete(id);

            //Assert
            Assert.True(actionResult != null);
        }
    }
}
