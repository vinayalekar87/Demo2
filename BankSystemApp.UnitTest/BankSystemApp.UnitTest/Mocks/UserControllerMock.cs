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
    public class UserControllerMock : IEnumerable<object[]>
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
            var userAccountService = UserControllerDependencies.GetIUserAccountService();
            yield return new object[] { userAccountService };
        }
    }

    internal static class UserControllerDependencies
    {
        internal static Mock<IUserAccountService> GetIUserAccountService()
        {
            var userAccountService = new Mock<IUserAccountService>();
            userAccountService.Setup(s => s.GetAllUserAccount()).Returns(Task.FromResult(GetUserAccountModel()));

            return userAccountService;
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
