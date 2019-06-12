using NCosmos.Library.Common;
using NCosmos.Library.Interface;
using NCosmos.Library.Models.Core;
using NCosmos.Library.Models.Messages;
using NCosmos.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NCosmos.Library.Implementation
{
    public class CosmosClient : ICosmosClientWrite
    {
        private static HttpClientHandler httpClientHandler = new HttpClientHandler();
        private static HttpClient client;

        private readonly string _serverUrl;
        private readonly bool _ignoreSslErrors;
        private readonly string _chainId;

        public CosmosClient(string chainId, string serverUrl, bool ignoreSslErrors = false)
        {
            _serverUrl = serverUrl;
            _ignoreSslErrors = ignoreSslErrors;
            _chainId = chainId;
        }
        public async Task<(HttpStatusCode, VersionInfo)> GetNodeInfoAsync()
        {
            EnsureClient();
            var response = await client.GetAsync("/node_info");
            return (response.StatusCode, await response.Content.ReadAsAsync<VersionInfo>());
        }

        public async Task<(HttpStatusCode, AccountInfo)> GetAccountInfoAsync(string fromAddressBech32)
        {
            EnsureClient();
            var response = await client.GetAsync($"/auth/accounts/{fromAddressBech32}");

            AminoMessage<AccountInfo> aminoMessage = await response.Content.ReadAsAsync<AminoMessage<AccountInfo>>();

            return (response.StatusCode, aminoMessage.Value);
        }

        public Uri GetServerUri()
        {
            var parsedUrl = new Uri(_serverUrl);
            return parsedUrl;
        }

        //TODO: Need to implement this
        public async Task<(HttpStatusCode, TxResponse)> TransferAsync(string fromAddressBech32, string toAddressBech32, long amountToSend, string coinToSend, long sequenceNumber, string privateKey, string message, long accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<(HttpStatusCode, Coin[])> GetBalanceAsync(string bech32Account)
        {
            EnsureClient();

            var response = await client.GetAsync($"/bank/balances/{bech32Account}");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (response.StatusCode, null);
            }

            return (response.StatusCode, await response.Content.ReadAsAsync<Coin[]>());
        }

        public async Task<(HttpStatusCode, TxResponse[])> GetTransactions(string bech32Account)
        {
            EnsureClient();

            string listTransactionRequests = $"/txs?{TransactionTags.TransactionSender}={bech32Account}&{TransactionTags.TransactionRecipient}={bech32Account}";
            var response = await client.GetAsync(listTransactionRequests);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (response.StatusCode, null);
            }

            var res = await response.Content.ReadAsAsync<TxResponse[]>();

            return (response.StatusCode, res);
        }

        public async Task<(HttpStatusCode, BlockInfo)> GetBlockDetailsByHeight(long height)
        {
            EnsureClient();

            string listTransactionRequests = $"/blocks/{height}";
            var response = await client.GetAsync(listTransactionRequests);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (response.StatusCode, null);
            }

            var res = await response.Content.ReadAsAsync<BlockInfo>();

            return (response.StatusCode, res);
        }

        private void EnsureClient()
        {
            if (client != null) return;

            SetupCertCheckIgnoreForDebug();

            client = new HttpClient(httpClientHandler);
            var baseAddress = this.GetServerUri();
            client.BaseAddress = baseAddress;
        }

        private void SetupCertCheckIgnoreForDebug()
        {
            if (!_ignoreSslErrors) return;

            httpClientHandler.ServerCertificateCustomValidationCallback = (message,
                cert, chain, errors) =>
            { return true; };
        }

        public async Task<(HttpStatusCode, TxResponse[])> GetSenderTransactions(string bech32Account)
        {
            EnsureClient();

            string listTransactionRequests = $"/txs?{TransactionTags.TransactionSender}={bech32Account}";
            var response = await client.GetAsync(listTransactionRequests);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (response.StatusCode, null);
            }

            var res = await response.Content.ReadAsAsync<TxResponse[]>();

            return (response.StatusCode, res); throw new NotImplementedException();
        }

        public async Task<(HttpStatusCode, TxResponse[])> GetRecipientTransactions(string bech32Account)
        {
            EnsureClient();

            string listTransactionRequests = $"/txs?{TransactionTags.TransactionRecipient}={bech32Account}";
            var response = await client.GetAsync(listTransactionRequests);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (response.StatusCode, null);
            }

            var res = await response.Content.ReadAsAsync<TxResponse[]>();

            return (response.StatusCode, res); throw new NotImplementedException();
        }
    }
}