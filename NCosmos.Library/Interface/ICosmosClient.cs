using NCosmos.Library.Models.Core;
using NCosmos.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCosmos.Library.Interface
{
    public interface ICosmosClientRead
    {
        Task<(HttpStatusCode, AccountInfo)> GetAccountInfoAsync(string fromAddressBech32);
        Task<(HttpStatusCode, Coin[])> GetBalanceAsync(string bech32Account);
        Task<(HttpStatusCode, VersionInfo)> GetNodeInfoAsync();
        Uri GetServerUri();
        Task<(HttpStatusCode, TxResponse[])> GetTransactions(string bech32Account);
        Task<(HttpStatusCode, TxResponse[])> GetSenderTransactions(string bech32Account);
        Task<(HttpStatusCode, TxResponse[])> GetRecipientTransactions(string bech32Account);

        Task<(HttpStatusCode, BlockInfo)> GetBlockDetailsByHeight(long height);

    }

    public interface ICosmosClientWrite : ICosmosClientRead
    {
        Task<(HttpStatusCode, TxResponse)> TransferAsync(string fromAddressBech32, string toAddressBech32, long amountToSend, string coinToSend, long sequenceNumber, string privateKey, string message, long accountNumber);

    }
}
