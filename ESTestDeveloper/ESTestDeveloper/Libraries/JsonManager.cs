using ESTestDeveloper.Models;
using Newtonsoft.Json;
using System.IO;

namespace ESTestDeveloper.Libraries
{
    public class JsonManager
    {
        public static Database DeserializeJson(string path)
        {
            string txt = File.ReadAllText(path);
            var json = JsonConvert.DeserializeObject<Database>(txt);
            return json;
        }

        public static void SerializeJson(string path, object data)
        {
            var txt = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, txt);
        }
    }
}
