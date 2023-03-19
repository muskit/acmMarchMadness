using System.Numerics;
using System.IO;

class Program
{
    // GNacci func is FUNCTIONAL!
    static uint GNacci(uint g, uint i)
	{
        // constant modulo
        ulong MOD = (ulong)BigInteger.Pow(new BigInteger(10), 7) + 7;

        if (i == 0)
            return 0;
		else if(i < g)
			return 1;
		else
		{
            var fibArray = new ulong[i];
			fibArray[0] = 0;
            for(uint j = 1; j < g; ++j)
                fibArray[j] = 1;
			fibArray[g] = g-1;

			for(uint j = g + 1; j < i; j++)
			{
                fibArray[j] = 0;
                for(uint n = 0; n <= g; n++)
                {
                    fibArray[j] += fibArray[j - n] % MOD;
                }
			}
			
			return (uint)(fibArray[i-1] % MOD);
		}
	}
    
    static string RemoveSymbols(string s)
    {
        return new string((from c in s
                    where char.IsLetterOrDigit(c) || c == ' '
                    select c
                    ).ToArray())!;
    }
    static void Main()
    {
        Console.WriteLine("[Testing g-Nacci]");
        Console.WriteLine($"3g[4] = {GNacci(3, 4)} (expect 2)");
        Console.WriteLine($"3g[5] = {GNacci(3, 5)} (expect 4)");
        Console.WriteLine($"3g[6] = {GNacci(3, 6)} (expect 7)");
        Console.WriteLine($"3g[12] = {GNacci(3, 12)} (expect 274)");
        Console.WriteLine("-------------- MODULO CALIBRATION VALUES --------------");
        Console.WriteLine($"2g[10] = {GNacci(2, 10)} (expect 34)");
        Console.WriteLine($"6g[201] = {GNacci(6, 201)} (expect 5006161)");
        Console.WriteLine($"7g[1999] = {GNacci(7, 1999)} (expect 8039002)");
        Console.WriteLine();

        var routeToGN = new Dictionary<uint, string>();
        var routeAccIncome = new Dictionary<uint, int>();

        var input = File.ReadAllText("input.txt");
        var srInput = new StringReader(input);
        
        var lineOfCounts = srInput.ReadLine()!;
        // count vars
        var words = lineOfCounts.Split();
        var nAccounts = int.Parse(words[0]);
        var nTransactions = int.Parse(words[1]);

        // set up account numbers
        for(int i = 0; i < nAccounts; ++i)
        {
            words = srInput.ReadLine()!.Split();
            var g = uint.Parse(words[0]);
            var step = uint.Parse(words[1]);
            
            var accountNumber = GNacci(g, step);
            routeAccIncome[accountNumber] = 0;
            routeToGN[accountNumber] = words[0]+words[1];
            Console.WriteLine($"{routeToGN[accountNumber]}: {accountNumber}");
        }

        // process transactions
        for(int i = 0; i < nTransactions; ++i)
        {
            words = RemoveSymbols(srInput.ReadLine()!).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(String.Join(", ", words)); 
            var sender = uint.Parse(words[1]);
            var recipient = uint.Parse(words[1]);
            var amount = int.Parse(words[2]);
            routeAccIncome[recipient] += amount;
            // routeAccIncome[sender] -= amount;
        }

        // print out transactions
        foreach(var kv in routeAccIncome)
        {
            Console.WriteLine($"{routeToGN[kv.Key]}: {kv.Value}");
        }

        var kvOfMax = 
            routeAccIncome.Aggregate((x, y) => x.Value > y.Value ? x : y);
        Console.WriteLine($"Account w/ highest income: {routeToGN[kvOfMax.Key]} (${kvOfMax.Value})");
    }
}