using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using UnitTests.Common;
using static UnitTests.Properties.Settings;

namespace UnitTests
{
    /// <summary>
    /// Test de autenticación y autorización
    /// </summary>
    [TestClass]
    public class AuthUnitTest: BaseUnitTest
    {
        [TestMethod]
        public async Task LoginTest()
        {
            // Chequea que por defecto no esté la sesión iniciada
            Assert.IsFalse(AuthProvider.IsLoggedIn());

            // Chequea iniciar sesión
            var loginAccepted = await AuthProvider.Login(Default.USERNAME, Default.PASSWORD);
            Assert.IsTrue(loginAccepted);
            Assert.IsTrue(AuthProvider.IsLoggedIn());

            // Chequea cerrar sesión
            await AuthProvider.Logout();
            Assert.IsFalse(AuthProvider.IsLoggedIn());

            // Chequea iniciar sesión con credenciales inválidas
            var loginRejected = await AuthProvider.Login(12345674, 1234);
            Assert.IsFalse(loginRejected);
            Assert.IsFalse(AuthProvider.IsLoggedIn());
        }
    }
}
