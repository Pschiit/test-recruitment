using ESTestDeveloper.Models;
using System.Collections.Generic;
using System.Linq;

namespace ESTestDeveloper.Libraries
{
    public class PlayerManager
    {
        private const string _playerFile = @".\Resources\database.json";

        public static List<Player> GetAllPlayers()
        {
            return JsonManager.DeserializeJson(_playerFile).Players.OrderBy(p => p.Id).ToList();

        }

        public static Player GetPlayersById(int id)
        {
            return JsonManager.DeserializeJson(_playerFile).Players.Find(p => p.Id == id);

        }

        public static bool DeletePlayerById(int id)
        {
            var data = JsonManager.DeserializeJson(_playerFile);
            var deletedPlayer = data.Players.Find(p => p.Id == id);
            if (deletedPlayer != null)
            {
                data.Players.Remove(deletedPlayer);
                JsonManager.SerializeJson(_playerFile, data);
                return true;
            }
            return false;
        }
    }
}
