using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.UnitTest.Mocks
{
    public class UserAccountRepositoryMock : IEnumerable<object[]>
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
}
