using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain;
using UnitTests.Common;
using static UnitTests.Properties.Settings;

namespace UnitTests
{
    /// <summary>
    /// Test de cuentas bancarias
    /// </summary>
    [TestClass]
    public class AccountUnitTest : BaseUnitTest
    {
        [TestInitialize]
        public async Task Initialize()
        {
            await AuthProvider.Login(Default.USERNAME, Default.PASSWORD);
        }

        [TestMethod]
        public async Task GetAccountBalanceTest()
        {
            var accountBalance = await AccountProvider.GetAccountBalance();
            Assert.IsInstanceOfType(accountBalance, typeof(AccountBalance));
        }

        [TestMethod]
        public async Task GetAccountMovementsTest()
        {
            var accountMovements = await AccountProvider.GetAccountMovements();
            Assert.IsInstanceOfType(accountMovements, typeof(IEnumerable<AccountMovement>));
        }
    }
}
