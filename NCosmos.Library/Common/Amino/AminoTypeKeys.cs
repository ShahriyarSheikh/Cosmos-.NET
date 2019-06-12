using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Common.Amino
{
    internal static class AminoTypeKeys
    {
        internal const string SigningPubKeyTypeSecp256k1 = "tendermint/PubKeySecp256k1";

        internal const string BankSendMessage = "cosmos-sdk/MsgSend";

        internal const string BankSendMultiMessage = "cosmos-sdk/MsgMultiSend";

        internal const string StdTx = "auth/StdTx";
    }
}
