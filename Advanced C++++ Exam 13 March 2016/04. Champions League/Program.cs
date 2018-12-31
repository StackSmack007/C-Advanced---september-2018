using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string,Team> teams = new Dictionary<string,Team>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "stop")
            {
                break;
            }
            string team1 = input[0];
            string team2 = input[1];
            Enlist(teams, team1);
            Enlist(teams, team2);
            int[] goalsOnField1 = input[2].Split(':').Select(int.Parse).ToArray();//1stScored:2ndScored - 1st is host
            int[] goalsOnField2 = input[3].Split(':').Select(int.Parse).Reverse().ToArray();//1stScored:2ndScored - 2st is host
            teams[team1].Oponents.Add(team2);
            teams[team2].Oponents.Add(team1);
            if (IsTheFirstOneWinner(goalsOnField1, goalsOnField2))
            {
                teams[team1].Wins++;
            }
            else
            {
                teams[team2].Wins++;
            }
        }
        foreach (var kvp in teams.OrderByDescending(x=>x.Value.Wins).ThenBy(x=>x.Key))
        {
            Console.WriteLine(kvp.Key);
            Console.WriteLine("- Wins: {0}",kvp.Value.Wins);
            Console.WriteLine($"- Opponents: { string.Join(", ", kvp.Value.Oponents.OrderBy(x=>x))}");
        }
    }
    static void Enlist(Dictionary<string,Team> teams, string teamName)
    {
        if (!teams.ContainsKey(teamName))
        {
            teams[teamName] = new Team();
        }
    }

    static bool IsTheFirstOneWinner(int[] goalsField1, int[] goalsField2)
    {
        if (goalsField1[0] + goalsField2[0] > goalsField1[1] + goalsField2[1])
        {
            return true;
        }
        else if (goalsField1[0] + goalsField2[0] < goalsField1[1] + goalsField2[1])
        {
            return false;
        }
        else if (goalsField2[0]>goalsField1[1])
        {
            return true;
        }
  return false;    
    }

}

class Team
{
    public List<string> Oponents { get; set; } = new List<string>();
    public int Wins { get; set; } = 0;
}