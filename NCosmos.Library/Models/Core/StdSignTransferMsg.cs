using NCosmos.Library.Common;
using NCosmos.Library.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Core
{
    internal class StdSignTransferMsg
    {
        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("account_number", Order = 1)]
        public long AccountNumber { get; set; }

        [JsonProperty("chain_id", Order = 2)]
        public string ChainID { get; set; }

        [JsonProperty("fee", Order = 3)]
        public StdFee Fee { get; set; }

        [JsonProperty("memo", Order = 4)]
        public string Memo { get; set; }

        [JsonProperty("msgs", Order = 5)]
        public IAminoMessage[] Msgs { get; set; }

        [JsonConverter(typeof(LongToStringConverter))]
        [JsonProperty("sequence", Order = 7)]
        public long Sequence { get; set; }
    }
}
