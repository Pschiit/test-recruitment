using ESTestDeveloper.Libraries;
using ESTestDeveloper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ESTestDeveloper.Tests
{
    [TestClass]
    public class PlayerManagerTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            JsonManager.InitializeDatabase();
        }

        [TestMethod]
        public void GetAllPlayersTest()
        {
            var result = PlayerManager.GetAllPlayers();

            Assert.IsNotNull(result);
            CollectionAssert.AllItemsAreNotNull(result);
            var orderedList = new List<Player>(result);
            orderedList = orderedList.OrderBy(p => p.Id).ToList();
            CollectionAssert.AreEqual(orderedList, result);
        }
        [TestMethod]
        public void GetPlayerByIdTest()
        {
            var id = 52;
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
            var id = 52;
            var result = PlayerManager.DeletePlayerById(id);

            Assert.IsTrue(result);
            Assert.IsNull(PlayerManager.GetPlayersById(id));
        }
        [TestMethod]
        public void DeletePlayerByIdFailingTest()
        {
            var id = 51;

            var result = PlayerManager.DeletePlayerById(id);
            Assert.IsFalse(result);
        }
    }
}
