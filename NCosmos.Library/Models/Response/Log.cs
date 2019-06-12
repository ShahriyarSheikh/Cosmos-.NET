using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Response
{
    public class Log
    {
        [JsonProperty("msg_index")]
        public string Index { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("log")]
        public string Message { get; set; }
    }
}
