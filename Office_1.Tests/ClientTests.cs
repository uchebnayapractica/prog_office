using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Office_1.DataLayer;
using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;

namespace Office_1.Tests
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
            using var db = new ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Database.Migrate();
        }

        [Test]
        public void TestAddingClients()
        {
            Assert.IsEmpty(ClientService.GetAllClients()); // никого из клиентов не должно быть

            var client = MakeSomeClient();
            
            Assert.AreNotEqual(0, client.Id); // id вбился

            var allClients = ClientService.GetAllClients();
            Assert.AreEqual(1, allClients.Count); // теперь 1 клиент

            var gotClient = allClients.First();
            Assert.AreEqual(client.Name, gotClient.Name);
            Assert.AreEqual(client.Address, gotClient.Address);
            Assert.AreEqual(client.Id, gotClient.Id);
        }

        [Test]
        public void TestGetClientsByPrefix()
        {
            var client = MakeSomeClient();

            var clients = ClientService.GetClientsByPrefixOfName("Иван");
            Assert.IsNotEmpty(clients);

            var gotClient = clients.First();
            Assert.AreEqual(client.Id, gotClient.Id);

            clients = ClientService.GetClientsByPrefixOfName("Такого клиента нет");
            Assert.IsEmpty(clients);
        }

        [Test]
        public void TestGetOrCreateClient()
        {
            var client = ClientService.GetOrCreateClientByName("Иванов Иван Иванович", "улица Пушкина, дом Колотушкина");

            var allClients = ClientService.GetAllClients();
            Assert.AreEqual(1, allClients.Count); // проверяем что клиент создался 

            var gotClient = allClients.First();
            Assert.AreEqual(client.Id, gotClient.Id); // проверяем что это тот клиент, что мы создавали

            // теперь клиент должен быть просто получен, а не создан
            
            var sameClient = ClientService.GetOrCreateClientByName(client.Name, client.Address);
            Assert.AreEqual(client.Id, sameClient.Id);
            
            allClients = ClientService.GetAllClients();
            Assert.AreEqual(1, allClients.Count); // проверяем что клиент не создавался 
        }

        private static Client MakeSomeClient()
        {
            var client = new Client
            {
                Name = "Иванов Иван Иванович",
                Address = "улица Пушкина, дом Колотушкина"
            };
            
            ClientService.InsertClient(client);

            return client;
        }
    }
}