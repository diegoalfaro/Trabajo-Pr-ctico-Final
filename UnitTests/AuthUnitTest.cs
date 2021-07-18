using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTests
{
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

            var loginRejected = await AuthProvider.Login(12345674, 1234);
            Assert.IsFalse(loginRejected);
        }
    }
}
