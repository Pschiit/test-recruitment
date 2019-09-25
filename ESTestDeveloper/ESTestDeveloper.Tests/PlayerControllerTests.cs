using ESTestDeveloper.Controllers;
using ESTestDeveloper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ESTestDeveloper.Tests
{
    [TestClass]
    public class PlayerControllerTests
    {
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

            if (players.Count > 1)
                Assert.IsTrue(players[0].Id < players[1].Id);
        }

        [TestMethod]
        public void GetPlayersByIdTest()
        {
            //Get ID of first player in database to test request with a valid id
            var controller = new PlayerController();
            var playersResult = controller.Get();
            Assert.IsInstanceOfType(playersResult, typeof(OkObjectResult));
            var playersOk = playersResult as OkObjectResult;
            var playersValue = playersOk.Value;
            Assert.IsInstanceOfType(playersValue, typeof(List<Player>));
            var players = playersValue as List<Player>;
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count > 0);
            var player = players[0];
            Assert.IsNotNull(player);
            var id = player.Id;

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
            //Get ID of first player in database to test request with a valid id
            var controller = new PlayerController();
            var playersResult = controller.Get();
            Assert.IsInstanceOfType(playersResult, typeof(OkObjectResult));
            var playersOk = playersResult as OkObjectResult;
            var playersValue = playersOk.Value;
            Assert.IsInstanceOfType(playersValue, typeof(List<Player>));
            var players = playersValue as List<Player>;
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count > 0);
            var player = players[0];
            Assert.IsNotNull(player);
            var id = player.Id;

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
