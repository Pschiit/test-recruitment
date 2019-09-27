using ESTestDeveloper.Models;
using Newtonsoft.Json;
using System.IO;

namespace ESTestDeveloper.Libraries
{
    public class JsonManager
    {
        private const string _sourceFile = @".\Resources\headtohead.json";
        private const string _databaseFile = @".\Resources\database.json";

        public static void InitializeDatabase()
        {
            File.Delete(_databaseFile);
            File.Copy(_sourceFile, _databaseFile);
        }

        public static Database DeserializeJson()
        {
            string txt = File.ReadAllText(_databaseFile);
            var json = JsonConvert.DeserializeObject<Database>(txt);
            return json;
        }

        public static void SerializeJson(object data)
        {
            var txt = JsonConvert.SerializeObject(data);
            File.WriteAllText(_databaseFile, txt);
        }
    }
}
