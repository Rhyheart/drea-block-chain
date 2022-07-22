using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drea.BlockChain
{
    public class Record
    {
        /// <summary>
        /// 转账人
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 收账人
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
