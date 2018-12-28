using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string janre = Console.ReadLine();
        string durationPref = Console.ReadLine();
        Dictionary<string, int> movies = new Dictionary<string, int>();
        int playListDurationSecs = movies.Sum(x => x.Value);
        while (true)
        {
            string[] input = Console.ReadLine().Split('|');
            if (input[0] == "POPCORN!")
            {
                break;
            }
            playListDurationSecs += GetValueInSeconds(input[2]);
            string janreCurrent = input[1];
            if (janre != janreCurrent)
            {
                continue;
            }
            movies[input[0]] = GetValueInSeconds(input[2]);
        }
        if (durationPref == "Short")
        {
            movies = movies.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }
        else
        {
            movies = movies.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }
   
        foreach (var kvp in movies)
        {
            Console.WriteLine(kvp.Key);
            if (Console.ReadLine()=="Yes")
            {
                Console.WriteLine("We're watching {0} - {1}",kvp.Key,GetDateFromSeconds(kvp.Value));
                Console.WriteLine("Total Playlist Duration: {0}",GetDateFromSeconds(playListDurationSecs));
                break;
            }
        }
    }

    static int GetValueInSeconds(string duration)
    {
        int[] times = duration.Split(':').Select(int.Parse).ToArray();
        return times[0] * 60 * 60 + times[1] * 60 + times[2];
    }

    static string GetDateFromSeconds(int seconds)
    {
        int hours = seconds / (60 * 60);
        seconds -= hours * 60 * 60;
        int mins = seconds / 60;
        seconds -= mins * 60;
        return hours.ToString().PadLeft(2,'0')+':'+ 
            mins.ToString().PadLeft(2, '0') + ':' + 
            seconds.ToString().PadLeft(2, '0');
    }
}
//18:31