using BankSystemApp.Data;
using BankSystemApp.Interfaces;
using BankSystemApp.Models;
using BankSystemApp.Repository;
using BankSystemApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankSystemApp.UnitTest.Tests
{
    public class UserAccountRepositoryTest
    {
        [Fact]
        public async void GetAllUserAccountTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                },
                new UserAccountModel
                {
                    ContactNumber = 987456321,
                    UserName = "Test User 2",
                    Balance = 5000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountService = new UserAccountRepository();
            //Act
            var lstModel = await userAccountService.GetAllUserAccount();

            //Assert
            Assert.True(lstModel != null);
        }

        [Fact]
        public async void GetUserAccountDetailsByIdTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;

            //Act
            var lstModel = await userAccountRepository.GetUserAccountDetailsById(id);

            //Assert
            Assert.True(lstModel != null);
        }

        [Fact]
        public async void GetUserAccountDetailsByIdNegativeTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 99999;

            //Act
            //var lstModel = await userAccountService.GetUserAccountDetailsById(id);

            //Assert
            await Assert.ThrowsAnyAsync<ApplicationException>(async () => await userAccountRepository.GetUserAccountDetailsById(id));
        }

        [Fact]
        public async void CreateUserAccountTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            var lstModel = await userAccountRepository.CreateUserAccount(userModel);

            //Assert
            Assert.True(lstModel > -1);
        }

        [Fact]
        public async void UpdateUserAccountTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };

            //Act
            await userAccountRepository.UpdateUserAccount(id,userModel);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteUserAccountTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;

            //Act
            await userAccountRepository.DeleteUserAccount(id);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DepositTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;
            int amount = 200;

            //Act
            await userAccountRepository.Deposit(id, amount);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void WithdrawTest()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase(databaseName: "UnitTestDb");
            var options = builder.Options;

            using (var context = new ApiContext())
            {
                var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 123456789,
                    UserName = "Test User",
                    Balance = 2000
                }
                };
                context.UserAccount.AddRange(userAccounts);
                context.SaveChanges();
            }

            //Arrange
            var userAccountRepository = new UserAccountRepository();
            int id = 2;
            int amount = 200;

            //Act
            await userAccountRepository.Withdraw(id, amount);

            //Assert
            Assert.True(true);
        }
    }
}
