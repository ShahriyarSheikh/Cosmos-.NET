using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Common
{
    internal static class TransactionTags
    {
        /// <summary>
        /// The transaction tags like action, send 
        /// result in endpoints like 'GET /txs?action=submit-proposal&proposer=yourcoin1fsfwrxhht5rmqven628nklxluzyv8z9jqjcqr'
        /// </summary>
        public static readonly string TransactionAction = "action";

        public static readonly string TransactionActionSend = "send";

        public static readonly string TransactionSender = "sender";

        public static readonly string TransactionRecipient = "recipient";
    }
}
