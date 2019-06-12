using NCosmos.Library.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Core
{
    public class StdFee
    {
        [JsonProperty("amount", Order = 1)]
        public Coin[] Amount { get; set; }

        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("gas", Order = 2)]
        public long Gas { get; set; }
    }
}
