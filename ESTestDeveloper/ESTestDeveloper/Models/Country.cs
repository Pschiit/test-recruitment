using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESTestDeveloper.Models
{
    public class Country
    {
        public string Picture { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode Code { get; set; }
    }
}
