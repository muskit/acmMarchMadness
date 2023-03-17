using System;
using System.Collections.Generic;

public struct Flight
{
    public string dest { get; init; }
    public TimeSpan waitDuration { get; init; }
    public TimeSpan flightDuration { get; init; }
    public TimeSpan TotalDuration
    {
        get
        {
            return flightDuration + waitDuration;
        }
    }

    public Flight(string dest, int[] waitDuration, int[] flightDuration)
    {
        this.dest = dest;
        this.waitDuration = new TimeSpan(waitDuration[0], waitDuration[1], 0);
        this.flightDuration = new TimeSpan(flightDuration[0], flightDuration[1], 0);
    }
}

class Solution
{
    Dictionary<string, Dictionary<string, Flight>> flights = new Dictionary<string, Dictionary<string, Flight>>();
    
    // vars used in Dijkstra's
    string start;
    string end;
    PriorityQueue<string, int> visitedNodes;

    // Initialize members
    public Solution(string inputFileName)
    {
        string input = System.IO.File.ReadAllText(inputFileName);
        using (StringReader reader = new StringReader(input))
        {
            start = reader.ReadLine();
            end = reader.ReadLine();
            reader.ReadLine(); // skip line count

            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                var words = line.Split();
                var nSrc = words[0];
                var nDest = words[1];
                var nWaitDur = (from word in words[2].Split(":") select Int32.Parse(word)).ToArray();
                var nFlyDur = (from word in words[3].Split(":") select Int32.Parse(word)).ToArray();

                var nFlight = new Flight(nDest, nWaitDur, nFlyDur);

                // check if depart key exists -- create if doesn't
                if (!flights.ContainsKey(nSrc))
                    flights[nSrc] = new Dictionary<string, Flight>();

                // check if destination key exists and compare flight time
                if (flights[nSrc].ContainsKey(nDest) &&
                    flights[nSrc][nDest].TotalDuration > nFlight.TotalDuration)
                {
                    flights[nSrc][nDest] = nFlight;
                }

                // create new destination flight
                else
                {
                    // Console.WriteLine($"[{nSrc} -> {nFlight.dest}] w:{nFlight.waitDuration}, f:{nFlight.flightDuration}");
                    flights[nSrc][nDest] = nFlight;
                }
            }
        }

        // print out flights
        foreach (var k in flights.Keys)
        {
            Console.WriteLine($"{k} ==>");
            foreach (var f in flights[k].Values)
            {
                Console.WriteLine($"\t{f.dest} ({f.TotalDuration})");
            }
        }
    }

    // Find time of shortest itinerary using Dijkstra's algorithm.
    int GetShortestMinutes(string src, string dest)
    {
        
        return -1;
    }

    public void Run()
    {
        Console.WriteLine(GetShortestMinutes(start, end));
    }
}

class Program
{
    static void Main()
    {
        var s = new Solution("input.txt");
        s.Run();
    }
}