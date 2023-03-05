using BankSystemApp.Interfaces;
using BankSystemApp.Models;
using BankSystemApp.Services;
using BankSystemApp.UnitTest.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystemApp.UnitTest.Tests
{
    public class UserAccountServiceTest
    {
        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void GetAllUserAccountTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            //Act
            var lstModel = await userAccountService.GetAllUserAccount();

            //Assert
            Assert.True(lstModel != null);
        }
        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void CreateUserAccountTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            var result = await userAccountService.CreateUserAccount(userModel);

            //Assert
            Assert.True(result > -1);
        }
        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void UpdateUserAccountTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            await userAccountService.UpdateUserAccount(id, userModel);

            //Assert
            Assert.True(true);
        }
        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void DeleteUserAccountTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;

            //Act
            await userAccountService.DeleteUserAccount(id);

            //Assert
            Assert.True(true);
        }

        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void DepositNegativeTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            int amount = 10001;

            //Act
            //await userAccountService.Deposit(id, amount);

            //Assert
            await Assert.ThrowsAnyAsync<ApplicationException>(async () => await userAccountService.Deposit(id, amount));
        }

        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void DepositTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            int amount = 9999;

            //Act
            await userAccountService.Deposit(id, amount);

            //Assert
            Assert.True(true);
        }

        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void WithdrawNegativeTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            int amount = 1950;

            //Act

            //Assert
            await Assert.ThrowsAnyAsync<ApplicationException>(async () => await userAccountService.Withdraw(id, amount));
        }

        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void WithdrawNegative2Test(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            int amount = 1810;

            //Act

            //Assert
            await Assert.ThrowsAnyAsync<ApplicationException>(async () => await userAccountService.Withdraw(id, amount));
        }

        [Theory]
        [ClassData(typeof(UserAccountServiceMock))]
        public async void WithdrawTest(Mock<IUserAccountRepository> userAccountRepository)
        {
            //Arrange
            var userAccountService = new UserAccountService(userAccountRepository.Object);
            int id = 1;
            int amount = 1000;

            //Act
            await userAccountService.Withdraw(id, amount);

            //Assert
            Assert.True(true);
        }
    }
}
