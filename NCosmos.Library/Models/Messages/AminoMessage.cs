using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Messages
{
    public class AminoMessage<T> : IAminoMessage
    {
        [JsonProperty("type", Order = 1)]
        public string Type { get; set; }

        [JsonProperty("value", Order = 2)]
        public T Value { get; set; }
    }
}
