using NCosmos.Library.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Core
{
    public class Coin
    {
        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("amount", Order = 1)]
        public long Amount { get; set; }

        [JsonProperty("denom", Order = 2)]
        public string Denom { get; set; }
    }
}
