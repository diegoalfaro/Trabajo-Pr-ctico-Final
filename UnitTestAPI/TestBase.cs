using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using API;

namespace UnitTestAPI
{
    [TestClass]
    public class TestBase
    {
        [TestMethod]
        public void SendTest()
        {
            var api = new API.Connectors.BaseConnector("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db");

            var httpMessage = api.SendAsync<API.Components.JsonResponse>(Method: "GET", URI: "/clients?id=12345678&pass=1234");

            httpMessage.Wait();

            dynamic body = httpMessage.Result.ToJson();

            Console.WriteLine(body[0].response.client.name);
        }

        [TestMethod]
        public void SendTest2()
        {
            var api = new API.Connectors.BaseConnector("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db");

            var task = api.SendAsync(Method: "GET", URI: "/clients?id=12345678&pass=1234");

            task.ContinueWith((pResponse) =>
            {
                Console.WriteLine(pResponse.Result.Body);
            });

            task.Wait();
        }
    }
}
