using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTests
{
    /// <summary>
    /// Test de autenticación y autorización
    /// </summary>
    [TestClass]
    public class AuthUnitTest: BaseUnitTest
    {

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task LoginTest()
        {
            var loginAccepted = await AuthProvider.Login(12345678, 1234);
            Assert.IsTrue(loginAccepted);
            Assert.IsTrue(AuthProvider.IsLoggedIn());

            await AuthProvider.Logout();

            Assert.IsFalse(AuthProvider.IsLoggedIn());

            var loginRejected = await AuthProvider.Login(12345674, 1234);
            Assert.IsFalse(loginRejected);
            Assert.IsFalse(AuthProvider.IsLoggedIn());
        }
    }
}
