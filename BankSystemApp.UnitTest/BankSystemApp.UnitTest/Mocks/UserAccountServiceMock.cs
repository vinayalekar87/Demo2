using BankSystemApp.Interfaces;
using BankSystemApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BankSystemApp.Interfaces;
using BankSystemApp.Models;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.UnitTest.Mocks
{
    public class UserAccountServiceMock : IEnumerable<object[]>
    {
        /// <summary>
        /// GetEnumerator method for initialize data and objects
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// GetEnumerator method
        /// </summary>
        /// <returns></returns>
        public IEnumerator<object[]> GetEnumerator()
        {
            var userAccountRepository = UserDependencies.GetIUserAccountRepository();
            yield return new object[] { userAccountRepository };
        }
    }

    internal static class UserDependencies
    {
        internal static Mock<IUserAccountRepository> GetIUserAccountRepository()
        {
            var userModel = new UserAccountModel
            {
                ContactNumber = 8983769626,
                UserName = "Vinay",
                Balance = 2000
            };
            var userAccountRepository = new Mock<IUserAccountRepository>();
            userAccountRepository.Setup(s => s.GetAllUserAccount()).Returns(Task.FromResult(GetUserAccountModel()));
            userAccountRepository.Setup(s => s.GetUserAccountDetailsById(It.IsAny<int>())).Returns(Task.FromResult(userModel));

            return userAccountRepository;
        }

        internal static List<UserAccountModel> GetUserAccountModel()
        {
            var userAccounts = new List<UserAccountModel>
                {
                new UserAccountModel
                {
                    ContactNumber = 8983769626,
                    UserName = "Vinay",
                    Balance = 2000
                },
                new UserAccountModel
                {
                    ContactNumber = 9822456545,
                    UserName = "Raj",
                    Balance = 5000
                }
                };
            return userAccounts;
        }
    }
}
