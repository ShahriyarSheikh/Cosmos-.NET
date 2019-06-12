using System;
using System.Collections.Generic;
using System.Text;

namespace NCosmos.Library.Models.Core
{
    public class BlockMeta
    {
        public BlockId block_id { get; set; }
        public Header header { get; set; }
    }

    public class Block
    {
        public Header header { get; set; }
        public Data data { get; set; }
        public Evidence evidence { get; set; }
        public LastCommit last_commit { get; set; }
    }

    public class Parts
    {
        public string total { get; set; }
        public string hash { get; set; }
    }

    public class BlockId
    {
        public string hash { get; set; }
        public Parts parts { get; set; }
    }

    public class Version
    {
        public string block { get; set; }
        public string app { get; set; }
    }

    public class LastBlockId
    {
        public string hash { get; set; }
        public Parts parts { get; set; }

    }

    public class Header
    {
        public Version version { get; set; }
        public string chain_id { get; set; }
        public string height { get; set; }
        public string time { get; set; }
        public string num_txs { get; set; }
        public string total_txs { get; set; }
        public LastBlockId last_block_id { get; set; }
        public string last_commit_hash { get; set; }
        public string data_hash { get; set; }
        public string validators_hash { get; set; }
        public string next_validators_hash { get; set; }
        public string consensus_hash { get; set; }
        public string app_hash { get; set; }
        public string last_results_hash { get; set; }
        public string evidence_hash { get; set; }
        public string proposer_address { get; set; }
    }



    public class Data
    {
        public IList<string> txs { get; set; }
    }

    public class Evidence
    {
        public object evidence { get; set; }
    }

    public class Precommit
    {
        public int type { get; set; }
        public string height { get; set; }
        public string round { get; set; }
        public string timestamp { get; set; }
        public BlockId block_id { get; set; }
        public string validator_address { get; set; }
        public string validator_index { get; set; }
        public string signature { get; set; }
    }

    public class LastCommit
    {
        public BlockId block_id { get; set; }
        public IList<Precommit> precommits { get; set; }
    }

    public class BlockInfo
    {
        public BlockMeta block_meta { get; set; }
        public Block block { get; set; }
    }
}