using ESTestDeveloper.Models;
using System.Collections.Generic;
using System.Linq;

namespace ESTestDeveloper.Libraries
{
    public class PlayerManager
    {

        public static List<Player> GetAllPlayers()
        {
            return JsonManager.DeserializeJson().Players.OrderBy(p => p.Id).ToList();

        }

        public static Player GetPlayersById(int id)
        {
            return JsonManager.DeserializeJson().Players.Find(p => p.Id == id);

        }

        public static bool DeletePlayerById(int id)
        {
            var data = JsonManager.DeserializeJson();
            var deletedPlayer = data.Players.Find(p => p.Id == id);
            if (deletedPlayer != null)
            {
                data.Players.Remove(deletedPlayer);
                JsonManager.SerializeJson(data);
                return true;
            }
            return false;
        }
    }
}
