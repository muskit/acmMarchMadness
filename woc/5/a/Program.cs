using System.IO;

class Program
{
    static string RemoveSymbols(string s)
    {
        return new string((from c in s
                    where char.IsLetterOrDigit(c)
                    select c
                    ).ToArray())!;
    }
    static void Main()
    {
        // money counters
        int checkSum = 0;
        double totalTax = 0;

        // low, high, rate
        var taxRates = new List<Tuple<int, int, int>>();

        string input = File.ReadAllText("input.txt");
        using (var sr = new StringReader(input))
        {
            var nBrackets = Int32.Parse(sr.ReadLine()!);
            var nPaychecks = Int32.Parse(sr.ReadLine()!);

            // taxable ranges
            for(int i = 0; i < nBrackets; ++i)
            {
                var words = sr.ReadLine()!.Split();

                // filter out chars
                for(int w = 0; w < words.Length; ++w)
                {
                    words[w] = RemoveSymbols(words[w]);
                }
                var low = Int32.Parse(words[0]);
                var high = Int32.Parse(words[1]);
                var rate = Int32.Parse(words[2]);
                taxRates.Add(new Tuple<int, int, int>(low, high, rate));
                Console.WriteLine($"{low}-{high}: {rate}%");
            }

            // read paychecks
            for(int i = 0; i < nPaychecks; ++i)
            {
                var line = sr.ReadLine()!;

                var checkStr = RemoveSymbols(line);
                var check = Int32.Parse(checkStr);
                if (check > 100)
                {
                    checkSum += check;
                    Console.WriteLine(check);
                }
                else
                {
                    Console.WriteLine($"Skipping {check} because <= 100");
                }
            }
        }

        // calculate tax rates
        foreach (var rate in taxRates)
        {
            if (checkSum >= rate.Item1)
            {
                double curTax = (Int32.Min(rate.Item2, checkSum) - rate.Item1 + 1) * ((double)rate.Item3/100);
                totalTax += curTax;
                Console.WriteLine($"{rate}: {curTax.ToString("0.000")}");
            }
        }
        Console.WriteLine($"Sum of checks: {checkSum}");
        Console.WriteLine($"We need to pay {totalTax} in taxes.");
    }
}