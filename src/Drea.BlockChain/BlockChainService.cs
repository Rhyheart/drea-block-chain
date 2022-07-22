namespace Drea.BlockChain
{
    public class BlockChainService
    {
        public IList<Block> Chain { set; get; }

        public BlockChainService()
        {
            InitializeChain();
        }

        /// <summary>
        /// 初始化区块链
        /// </summary>
        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        /// <summary>
        /// 添加创世区块
        /// </summary>
        /// <param name="records"></param>
        public void AddGenesisBlock(List<Record> records)
        {
            Chain.Add(new Block(0, "", records));
        }

        /// <summary>
        /// 获取最新区块
        /// </summary>
        /// <returns></returns>
        public Block GetLatestBlock()
        {
            return Chain.Last();
        }

        /// <summary>
        /// 添加区块
        /// </summary>
        /// <param name="records"></param>
        public void AddBlock(List<Record> records)
        {
            var latestBlock = GetLatestBlock();
            Chain.Add(new Block(latestBlock.Index + 1, latestBlock.Hash, records));
        }

        /// <summary>
        /// 验证当前区块链数据是否合规
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (Chain[0].Hash != Chain[0].CalculateHash())
            {
                return false;
            }

            for (var i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
