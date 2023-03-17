using System.Collections.Generic;
class ASolution
{
    static void MainDISABLE()
    {
        string input = System.IO.File.ReadAllText("room.txt");

        int numPeople = 0;
        int maxPeople = 0;

        using (StringReader reader = new StringReader(input))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("entered the room"))
                {
                    // var words = line.Split(" entered the room");
                    // Console.WriteLine($"{words[0]}: {words[1]}");
                    numPeople++;
                }
                else if (line.Contains("left the room"))
                {
                    // var words = line.Split(" left the room");
                    // Console.WriteLine($"{words[0]}: {words[1]}");
                    numPeople--;
                }
                maxPeople = Math.Max(numPeople, maxPeople);
            }
        }
        Console.WriteLine(maxPeople);
    }
}