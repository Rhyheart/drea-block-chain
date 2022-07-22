using Drea.BlockChain;
using Newtonsoft.Json;

var blockChainService = new BlockChainService();

#region 创世区块

Console.WriteLine("创世人 Rhyheart 创建了区块链，开始添加创世区块...");

var records = new List<Record>
{
    new Record
    {
        Sender = "System",
        Receiver = "Rhyheart",
        Amount = 50
    }
};

blockChainService.AddGenesisBlock(records);

Console.WriteLine("创世区块添加成功，创世人 Rhyheart 获得系统奖励的 50 个虚拟货币");
Console.WriteLine();

#endregion

#region 第二区块

Console.WriteLine("交易进行中...");

var records2 = new List<Record>
{
    new Record
    {
        Sender = "Rhyheart",
        Receiver = "Mark",
        Amount = 5
    },
    new Record
    {
        Sender = "Rhyheart",
        Receiver = "Frank",
        Amount = 5
    },
    new Record
    {
        Sender = "Rhyheart",
        Receiver = "Mark",
        Amount = 10
    },
    new Record
    {
        Sender = "Rhyheart",
        Receiver = "Jack",
        Amount = 5
    },
    new Record
    {
        Sender = "Mark",
        Receiver = "Rhyheart",
        Amount = 5
    }
};

Console.WriteLine("产生了 5 笔新交易，符合区块打包规则，用户们开始争夺第二区块添加权...");

Console.WriteLine("用户 Frank 争夺成功，获得区块添加权，开始添加第二区块...");

blockChainService.AddBlock(records2);

Console.WriteLine("第二区块添加成功，用户 Frank 获得系统奖励的 50 个虚拟货币");

Console.WriteLine();

#endregion

#region 第三区块

Console.WriteLine("交易进行中...");

var records3 = new List<Record>
{
    new Record
    {
        Sender = "System",
        Receiver = "Frank",
        Amount = 50
    },
    new Record
    {
        Sender = "Frank",
        Receiver = "Mark",
        Amount = 5
    },
    new Record
    {
        Sender = "Mark",
        Receiver = "Frank",
        Amount = 5
    },
    new Record
    {
        Sender = "Frank",
        Receiver = "Mark",
        Amount = 10
    },
    new Record
    {
        Sender = "Frank",
        Receiver = "Jack",
        Amount = 5
    },
    new Record
    {
        Sender = "Mark",
        Receiver = "Rhyheart",
        Amount = 5
    }
};

Console.WriteLine("产生了 5 笔新交易，符合区块打包规则，用户们开始争夺第三区块添加权...");

Console.WriteLine("用户 Mark 争夺成功，获得区块添加权，开始添加第三区块...");

blockChainService.AddBlock(records3);

Console.WriteLine("第二区块添加成功，用户 Mark 获得系统奖励的 50 个虚拟货币");

Console.WriteLine();

#endregion

Console.WriteLine($"区块链数据验证：{blockChainService.IsValid()}");
Console.WriteLine();

var totalAmount = blockChainService.Chain.Sum(x => x.Data.Where(x => x.Sender == "System").Sum(y => y.Amount));
Console.WriteLine($"区块链总虚拟货币数：{totalAmount}");
Console.WriteLine();

var receiveAmount = blockChainService.Chain.Sum(x => x.Data.Where(x => x.Receiver == "Rhyheart").Sum(y => y.Amount));
var sendAmount = blockChainService.Chain.Sum(x => x.Data.Where(x => x.Sender == "Rhyheart").Sum(y => y.Amount));
var amount = receiveAmount - sendAmount;
Console.WriteLine($"区块链 Rhyheart 用户虚拟货币余额：{amount}");
Console.WriteLine();

var chain = JsonConvert.SerializeObject(blockChainService.Chain);
Console.WriteLine($"区块链详情：{chain}");
Console.WriteLine();