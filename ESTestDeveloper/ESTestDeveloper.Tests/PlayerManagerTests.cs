using ESTestDeveloper.Libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESTestDeveloper.Tests
{
    [TestClass]
    public class PlayerManagerTests
    {
        [TestMethod]
        public void GetAllPlayersTest()
        {
            var result = PlayerManager.GetAllPlayers();
            Assert.IsNotNull(result);
            if (result.Count > 1)
                Assert.IsTrue(result[0].Id < result[1].Id);
        }

        [TestMethod]
        public void GetPlayerByIdTest()
        {
            //Get ID of first player in database to test with a valid id
            var players = PlayerManager.GetAllPlayers();
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count > 0);
            var player = players[0];
            Assert.IsNotNull(player);
            var id = player.Id;

            var result = PlayerManager.GetPlayersById(id);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == id);
        }
        [TestMethod]
        public void GetPlayerByIdFailingTest()
        {
            var id = 51;
            var result = PlayerManager.GetPlayersById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeletePlayerByIdTest()
        {
            //Get ID of first player in database to test with a valid id
            var players = PlayerManager.GetAllPlayers();
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count > 0);
            var player = players[0];
            Assert.IsNotNull(player);
            var id = player.Id;

            var result = PlayerManager.DeletePlayerById(id);
            Assert.IsTrue(result);
            Assert.IsNull(PlayerManager.GetPlayersById(id));
        }
        [TestMethod]
        public void DeletePlayerByIdFailingTest()
        {
            var id = 51;
            var player = PlayerManager.GetPlayersById(id);
            Assert.IsNull(player);
            var result = PlayerManager.DeletePlayerById(id);
            Assert.IsFalse(result);
        }
    }
}
