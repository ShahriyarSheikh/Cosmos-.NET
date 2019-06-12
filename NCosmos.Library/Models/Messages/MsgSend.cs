using NCosmos.Library.Models.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Messages
{
    public class MsgSend
    {
        [JsonProperty("amount", Order = 1)]
        public Coin[] Amount { get; set; }

        [JsonProperty("from_address", Order = 2)]
        public string FromAddress { get; set; }

        [JsonProperty("to_address", Order = 3)]
        public string ToAddress { get; set; }
    }
}
