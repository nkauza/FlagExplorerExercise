using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorerAPI.Domain
{
    public class CountryFlag
    {
        [JsonProperty("png")]
        public string? PNG { get; set; }

        [JsonProperty("svg")]
        public string? SVG { get; set; }

        [JsonProperty("alt")]
        public string? ALT { get; set; }
    }
}
