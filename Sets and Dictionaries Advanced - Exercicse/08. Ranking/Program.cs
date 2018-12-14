using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, string> contestPassword = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, int>> NameContestScore = new Dictionary<string, Dictionary<string, int>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(':');
            if (input[0] == "end of contests") break;
            string contest = input[0];
            string password = input[1];
            contestPassword[contest] = password;
        }
        while (true)
        {
            string[] input = Console.ReadLine().Split("=>");
            if (input[0] == "end of submissions") break;
            string contest = input[0];
            string password = input[1];
            string name = input[2];
            int points = int.Parse(input[3]);
            if (isValid(contest, password, contestPassword))
            {
                if (!NameContestScore.ContainsKey(name))
                {
                    NameContestScore[name] = new Dictionary<string, int> { { contest, points } };
                }
                else if (!NameContestScore[name].ContainsKey(contest))
                {
                    NameContestScore[name][contest] = points;
                }
                else
                {
                    NameContestScore[name][contest] = points > NameContestScore[name][contest] ? points : NameContestScore[name][contest];
                }
            }
        }
        var bestOne = NameContestScore.OrderByDescending(x => x.Value.Values.Sum()).First();
        Console.WriteLine($"Best candidate is {bestOne.Key} with total {bestOne.Value.Values.Sum()} points.\nRanking:");
        foreach (var kvp in NameContestScore.OrderBy(x=>x.Key))
        {
            Console.WriteLine(kvp.Key);
            foreach (var pair in kvp.Value.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine("#  {0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
    static bool isValid(string contest, string password, Dictionary<string, string> dict)
    {
        if (dict.ContainsKey(contest))
        {
            if (dict[contest] == password)
            {
                return true;
            }
        }
        return false;
    }
}