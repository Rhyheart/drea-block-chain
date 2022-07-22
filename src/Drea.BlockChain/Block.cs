using System.Security.Cryptography;
using System.Text;

namespace Drea.BlockChain
{
    public class Block
    {
        public Block(long index, string previousHash, List<Record> data)
        {
            Index = index;
            PreviousHash = previousHash;
            Data = data;
            TimeStamp = DateTime.Now;
            Nonce = Guid.NewGuid().ToString("N");
            Hash = CalculateHash();
        }

        /// <summary>
        /// 索引，区块高度
        /// </summary>
        public long Index { get; set; }

        /// <summary>
        /// 上个区块Hash值
        /// </summary>
        public string PreviousHash { get; set; }

        /// <summary>
        /// 当前区块存储的数据
        /// </summary>
        public List<Record> Data { get; set; }

        /// <summary>
        /// 区块创建时间
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// 随机数，用于改变Hash值，让其符合创世人设定的规则
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 当前区块Hash值
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <returns></returns>
        public string CalculateHash()
        {
            var sha256 = SHA256.Create();

            var inputBytes = Encoding.ASCII.GetBytes($"{PreviousHash}-{Data}-{TimeStamp}-{Nonce}");
            var outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
