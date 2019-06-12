using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCosmos.Library.Implementation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCosmos.UnitTests
{
    [TestClass]
    public class BroadcastTests
    {

        private static readonly string _testChainId = "test-chainid";
        private static readonly string _serverUrl = "http://localhost:8080";
        [TestMethod]
        public async Task VersionInfo_WhenGet_ReceivesInfoAsync()
        {
            var client = new CosmosClient(_testChainId, _serverUrl, true);

            var (status, result) = await client.GetNodeInfoAsync();

            Assert.IsNotNull(result);

            Assert.AreEqual("0.30.1", result.Version);
        }

        [TestMethod]
        public async Task GetAccountInfo_WhenExecuted_ReceivesInfoAsync()
        {
            const string fromAddressBech32 = "youcoinkz3kn33ljgdvrh2cuyacn4gv8a3ewcjx4ya87k";

            var client = new CosmosClient(_testChainId, _serverUrl, true);

            var (status, result) = await client.GetAccountInfoAsync(fromAddressBech32);

            Assert.AreEqual(HttpStatusCode.OK, status);

            Assert.IsNotNull(result);
        }

        //TODO: Need to implement this
        [TestMethod]
        public async Task Transfer_WhenExecuted_ReceivesSuccessRepsonseAsync()
        {
            Assert.Fail();

        }

        [TestMethod]
        public async Task GetBalance_WhenExecuted_Receives()
        {
            const string fromAddressBech32 = "youcoinkz3kn33ljgdvrh2cuyacn4gv8a3ewcjx4ya87k";

            var client = new CosmosClient(_testChainId, _serverUrl, true);

            var (status, result) = await client.GetBalanceAsync(fromAddressBech32);

            Assert.AreEqual(HttpStatusCode.OK, status);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTransactions_WhenExecuted_Receives()
        {
            const string fromAddressBech32 = "youcoinkz3kn33ljgdvrh2cuyacn4gv8a3ewcjx4ya87k";

            var client = new CosmosClient(_testChainId, _serverUrl, true);

            var (status, result) = await client.GetSenderTransactions(fromAddressBech32);

            Assert.AreEqual(HttpStatusCode.OK, status);

            Assert.IsNotNull(result);
        }
    }
}
