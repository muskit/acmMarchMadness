using System;
using System;
using System.Collections.Generic;
class BSolution
{
    static void Main()
    {
        string input = System.IO.File.ReadAllText("BRoom.txt");

        int numPeople = 0;
        int maxPeople = 0;

        using (StringReader reader = new StringReader(input))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.Contains("walked in"))
                {
                    var words = line.Split(' ');
                    numPeople += Int32.Parse(words[0]);
                    Console.WriteLine($"{Int32.Parse(words[0])} walked in");
                }
                if (line.Contains("walked out"))
                {
                    var words = line.Split(' ');
                    numPeople -= Int32.Parse(words[0]);
                    Console.WriteLine($"{Int32.Parse(words[0])} walked out");
                }
                else if (line.Contains("arrived") || line.Contains("entered"))
                {
                    string[] delimiters = {" and ", " others ", " other ", " entered the room", "arrived", " "};
                    var words =
                        line.Split(delimiters, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .ToList<string>();
                    
                    Console.WriteLine("[ENTERING]");
                    foreach (var word in words)
                    {
                        Console.WriteLine(word);
                    }
                    
                    if (Int32.TryParse(words.Last<string>(), out int num))
                    {
                        numPeople += words.Count-1 + num;
                        Console.WriteLine($"+{words.Count-1 + num}");
                    }
                    else
                    {
                        numPeople += words.Count;
                        Console.WriteLine($"+{words.Count}");
                    }
                }
                else if (line.Contains("departed") || line.Contains("exited"))
                {
                    string[] delimiters = {" and ", " others ", " other ", " exited the room", "departed", " "};
                    var words =
                        line.Split(delimiters, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .ToList<string>();

                    Console.WriteLine("[LEAVING]");
                    foreach (var word in words)
                    {
                        Console.WriteLine(word);
                    }
                    
                    if (Int32.TryParse(words.Last<string>(), out int num))
                    {
                        numPeople -= words.Count-1 + num;
                        Console.WriteLine($"-{words.Count-1 + num}");
                    }
                    else
                    {
                        numPeople -= words.Count;
                        Console.WriteLine($"-{words.Count}");
                    }
                }
                maxPeople = Math.Max(numPeople, maxPeople);
                Console.WriteLine();
            }
        }
        Console.WriteLine(maxPeople);
    }
}