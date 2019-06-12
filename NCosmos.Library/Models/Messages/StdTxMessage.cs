using NCosmos.Library.Common.Amino;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Messages
{
    public class StdTxMessage
    {
        [JsonIgnore]
        public string Type => AminoTypeKeys.StdTx;

        [JsonProperty("msg")]
        public AminoMessage<MsgSend>[] Messages { get; set; }
    }
}
