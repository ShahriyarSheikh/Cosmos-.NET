using NCosmos.Library.Common;
using NCosmos.Library.Models.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Response
{
    public class AccountInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("coins")]
        public Coin[] Coins { get; set; }

        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("account_number")]
        public long AccountNumber { get; set; }

        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("public_key")]
        public PubKey PubKey { get; set; }
    }
}
