using Newtonsoft.Json;

namespace FlagExplorerAPI.Domain
{
    public class Country
    {
        [JsonProperty("name")]
        public CountryName? Name { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("capital")]
        public string[]? Capital { get; set; }

        [JsonProperty("flags")]
        public CountryFlag? Flags { get; set; }
    }
}
