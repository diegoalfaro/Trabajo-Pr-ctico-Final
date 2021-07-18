using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain;
using UnitTests.Common;
using System;

namespace UnitTests
{
    /// <summary>
    /// Test de manejo de datos
    /// </summary>
    [TestClass]
    public class DataManagementUnitTest : BaseUnitTest
    {
        static private Client CreateRandomClient()
        {
            var random = new Random();

            var clientId = random.Next(1000, 999999);
            var password = random.Next(1000, 999999).ToString();

            var nameList = new List<string> { "Juan Pérez", "Rodrigo Noya", "Fabián Flores", "Manuel Ramírez" };
            var nameIndex = random.Next(nameList.Count);
            var name = nameList[nameIndex];

            ClientSegment clientSegment = random.NextDouble() < 0.75 ? ClientSegment.Selecta : ClientSegment.VIP;

            Client client = new Client()
            {
                ClientId = clientId,
                Password = password,
                Name = name,
                Segment = clientSegment
            };

            return client;
        }

        [TestMethod]
        public async Task UpsertClientTest()
        {
            Client upsertedClient = CreateRandomClient();
            Client gettedClient;

            using (DataManagementProvider)
            {
                await DataManagementProvider.Upsert(upsertedClient);
                await DataManagementProvider.SaveAsync();
                gettedClient = await DataManagementProvider.GetByID<Client>(upsertedClient.ClientId);
            }

            Assert.IsInstanceOfType(gettedClient, typeof(Client));
            Assert.AreEqual(upsertedClient.Name, gettedClient.Name);
        }
    }
}
