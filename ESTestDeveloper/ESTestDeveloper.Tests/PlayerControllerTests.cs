using ESTestDeveloper.Controllers;
using ESTestDeveloper.Libraries;
using ESTestDeveloper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ESTestDeveloper.Tests
{
    [TestClass]
    public class PlayerControllerTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            JsonManager.InitializeDatabase();
        }

        [TestMethod]
        public void GetAllPlayersTest()
        {
            var controller = new PlayerController();
            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = result as OkObjectResult;
            var value = ok.Value;
            Assert.IsInstanceOfType(value, typeof(List<Player>));
            var players = value as List<Player>;
            Assert.IsNotNull(players);
            CollectionAssert.AllItemsAreNotNull(players);
            var orderList = new List<Player>(players);
            orderList = orderList.OrderBy(p => p.Id).ToList();
            CollectionAssert.AreEqual(orderList, players);
        }

        [TestMethod]
        public void GetPlayersByIdTest()
        {
            var id = 52;
            var controller = new PlayerController();
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = result as OkObjectResult;
            var value = ok.Value;
            Assert.IsInstanceOfType(value, typeof(Player));
            var playerFound = value as Player;
            Assert.IsNotNull(playerFound);
            Assert.IsTrue(playerFound.Id == id);
        }
        [TestMethod]
        public void GetPlayerByIdFailingTest()
        {
            var id = 51;
            var controller = new PlayerController();
            var result = controller.Get(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void DeletePlayerByIdTest()
        {
            var id = 52;
            var controller = new PlayerController();
            var deleteResult = controller.Delete(id);

            Assert.IsInstanceOfType(deleteResult, typeof(OkResult));
            var result = controller.Get(id);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void DeletePlayerByIdFailingTest()
        {
            var id = 51;
            var controller = new PlayerController();
            var result = controller.Delete(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
