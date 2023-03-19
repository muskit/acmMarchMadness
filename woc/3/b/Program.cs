using System;
using System.Linq;
using MoreLinq;
using System.Collections.Generic;

class SrcTime
{
    public string src { get; set; }
    public int time { get; set; }
    public void SetTime(int newTime)
    {
        this.time = newTime;
    }
    public SrcTime(string a, int b)
    {
        src = a;
        time = b;
    }
}

public struct Flight
{
    public string dest { get; init; }
    public TimeSpan waitDuration { get; init; }
    public TimeSpan flightDuration { get; init; }
    public int TotalMinutes
    {
        get
        {
            return (int)TotalDuration.TotalMinutes;
        }
    }
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
    // flights and associated times; describes two nodes (start/dest) with weight (time)
    Dictionary<string, Dictionary<string, Flight>> flights = new Dictionary<string, Dictionary<string, Flight>>();
    
    // vars used in Dijkstra's
    string start;
    string end;
    Dictionary<string, SrcTime> timeFromStart = new Dictionary<string, SrcTime>(); // <dest, (src, total mins)>
    Dictionary<string, bool> visitedPlaces = new Dictionary<string, bool>();

    // Initialize members
    public Solution(string inputFileName)
    {
        string input = System.IO.File.ReadAllText(inputFileName);
        using (StringReader reader = new StringReader(input))
        {
            start = reader.ReadLine()!;
            end = reader.ReadLine()!;
            reader.ReadLine(); // skip line count

            for (string line = reader.ReadLine()!; line != null; line = reader.ReadLine()!)
            {
                var words = line.Split();
                var nSrc = words[0];
                var nDest = words[1];
                var nWaitDur = (from word in words[2].Split(":") select Int32.Parse(word)).ToArray();
                var nFlyDur = (from word in words[3].Split(":") select Int32.Parse(word)).ToArray();

                var nFlight = new Flight(nDest, nWaitDur, nFlyDur);

                // skip if wait time is longer than 3 hrs
                if (nFlight.waitDuration > new TimeSpan(3, 0, 0))
                    continue;

                // check if depart key exists -- create if doesn't
                if (!flights.ContainsKey(nSrc))
                    flights[nSrc] = new Dictionary<string, Flight>();

                // check if destination key exists and compare flight time
                if (flights[nSrc].ContainsKey(nDest) &&
                    nFlight.TotalDuration < flights[nSrc][nDest].TotalDuration)
                {
                    flights[nSrc][nDest] = nFlight;
                }

                // create new destination flight
                else
                {
                    flights[nSrc][nDest] = nFlight;
                }

                // add to timeFromStart for Dijkstra's
                if (!timeFromStart.ContainsKey(nDest))
                    timeFromStart[nDest] = new SrcTime("", Int32.MaxValue); //virtually infinity
                if (!timeFromStart.ContainsKey(nSrc))
                    timeFromStart[nSrc] = new SrcTime("", Int32.MaxValue); //virtually infinity
            }
        }
        timeFromStart[start].SetTime(0);

        // print out flights
        // foreach (var k in flights.Keys)
        // {
        //     Console.WriteLine($"{k} ==>");
        //     foreach (var f in flights[k].Values)
        //     {
        //         Console.WriteLine($"\t{f.dest} ({f.TotalDuration} or {f.TotalMinutes} minutes)");
        //     }
        // }
    }

    private void dijkstra(string curNode)
    {
        // update timeFromStart for each destNode from curNode
        foreach (var f in flights[curNode].Values)
        {
            if (curNode == end || !visitedPlaces.ContainsKey(f.dest))
            {
                var curTime = timeFromStart[curNode].time + f.TotalMinutes;
                if (curTime < timeFromStart[f.dest].time)
                {
                    var st = new SrcTime(curNode, timeFromStart[curNode].time + f.TotalMinutes);
                    timeFromStart[f.dest] = st;
                }
            }
        }

        visitedPlaces[curNode] = true;
        foreach(var pair in timeFromStart.OrderBy(kv => kv.Value.time))
        {
            if (!visitedPlaces.ContainsKey(pair.Key) && flights.ContainsKey(pair.Key))
            {
                dijkstra(pair.Key);
                break;
            }
        }

    }

    // Find time of shortest itinerary using Dijkstra's algorithm.
    public int GetShortestMinutes(string start, string dest)
    {
        // Populate timeFromStart (given the starting node)
        dijkstra(start);

        // backtrace flights, print flights taken and time
        Console.WriteLine("----- BACKTRACE -----");
        for(string curNode = dest; curNode != ""; curNode = timeFromStart[curNode].src)
        {
            var src = timeFromStart[curNode].src;
            if (timeFromStart[curNode].src != "")
            {
                Console.WriteLine($"{src} -> {curNode}: {timeFromStart[curNode].time}");
                Console.WriteLine($"\t{flights[src][curNode].TotalMinutes} minutes");
            }
        }
        return timeFromStart[dest].time;
    }

    public void Run()
    {
        Console.WriteLine($"Shortest flights length: {GetShortestMinutes(start, end)}");
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