using NCosmos.Library.Common;
using NCosmos.Library.Common.Amino;
using NCosmos.Library.Models.Core;
using NCosmos.Library.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Implementation
{
    internal class RequestCreator
    {
        public static StdSignTransferMsg CreateSendMessage(string chaingId, string coinToSend, string fromAddressBech32, string toAddressBech32, long amountToSend, long accountNumber, long sequenceNumber, string message)
        {
            return new StdSignTransferMsg
            {
                AccountNumber = accountNumber,
                ChainID = chaingId,
                Fee = new StdFee
                {
                    Amount = new[]{
                        new Coin
                        {
                            Amount = 0,
                            Denom = CoinTypes.YourCoin
                        }
                    },
                    Gas = 200000

                },
                Memo = message,
                Msgs = new IAminoMessage[]
                {
                    new AminoMessage<MsgSend>
                    {
                        Type = AminoTypeKeys.BankSendMessage,
                        Value = new MsgSend
                        {
                            FromAddress = fromAddressBech32,
                            ToAddress = toAddressBech32,
                            Amount = new Coin[]
                            {
                                new Coin
                                {
                                    Amount = amountToSend,
                                    Denom = coinToSend
                                }
                            }
                        }

                    }
                },
                Sequence = sequenceNumber
            };
        }
    }
}
