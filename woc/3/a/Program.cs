using System.Collections.Generic;


var flights = new Dictionary<string, string>();
string current, dest= null;
int elusive = 0;

// initialize the above working vars
string input = System.IO.File.ReadAllText("input.txt");
using (StringReader reader = new StringReader(input))
{
    current = reader.ReadLine();
    dest = reader.ReadLine();
    reader.ReadLine(); // skip line count

    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
    {
        var cities = line.Split();
        if(flights.ContainsKey(cities[0]))
        {
            Console.WriteLine($"[FATAL] Tried to insert {cities[0]} -> {cities[1]} when " +
                $"it already goes to {flights[cities[0]]}!");
            return;
        }
        flights[cities[0]] = cities[1];
        Console.WriteLine($"Added {cities[0]} -> {cities[1]}");
    }
}

while(current != dest)
{
    var next = flights[current];

    //do stuff
    var diff = next.Length - current.Length;
    if (diff > 0)
        elusive += 5;
    else if (diff < 0)
        elusive -= 2;

    current = next;
}

Console.WriteLine(elusive);