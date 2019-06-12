
using NCosmos.Library.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Response
{
    public class TxResponse
    {
        [JsonProperty("txhash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("tx")]
        public AminoMessage<StdTxMessage> Transaction { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("logs")]
        public List<Log> Log { get; set; }

        [JsonProperty("gas_wanted")]
        public string GasWanted { get; set; }

        [JsonProperty("gas_used")]
        public string GasUsed { get; set; }
    }
}
