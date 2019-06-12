using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Response
{
    public class VersionInfo
    {
        public ProtocolVersion ProtocolVersion { get; set; }
        public string Id { get; set; }
        public string ListenAddr { get; set; }
        public string Network { get; set; }
        public string Version { get; set; }
        public string Channels { get; set; }
        public string Moniker { get; set; }
        public Dictionary<string, string> Other { get; set; }
    }

    public class ProtocolVersion
    {
        public string P2p { get; set; }
        public string Block { get; set; }
        public string App { get; set; }

    }
}
