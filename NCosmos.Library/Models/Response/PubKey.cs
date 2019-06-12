using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Response
{
    public class PubKey
    {
        [JsonProperty("type", Order = 1)]
        public string Type { get; set; }

        [JsonProperty("value", Order = 2)]
        public string Value { get; set; }
    }
}
