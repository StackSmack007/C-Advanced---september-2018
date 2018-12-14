using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Stat> nameStat = new Dictionary<string, Stat>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "Statistics")
            {
                break;
            }
            string command = input[1];
            string name1 = input[0];
            string name2 = input[2];
            switch (command)
            {
                case "joined":
                    if (!nameStat.ContainsKey(name1))
                    {
                        nameStat[name1] = new Stat();
                    }
                    break;
                case "followed":
                    if (nameStat.ContainsKey(name2) & name1 != name2 & nameStat.ContainsKey(name1))
                    {
                        if (!nameStat[name2].Followers.Contains(name1))
                        {
                            nameStat[name2].Followers.Add(name1);
                            nameStat[name1].Following.Add(name2);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("The V-Logger has a total of {0} vloggers in its logs.", nameStat.Count);
        int counter = 1;
        foreach (var kvp in nameStat.OrderByDescending(x => x.Value.Followers.Count).ThenBy(y => y.Value.Following.Count))
        {
            Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Followers.Count} followers, {kvp.Value.Following.Count} following");
            if (counter == 1 & kvp.Value.Followers.Count>0)
            {
                foreach (string follower in kvp.Value.Followers.OrderBy(x=>x))
                {
                    Console.WriteLine("*  {0}", follower);
                }
            }
            counter++;
        }
    }
}
class Stat
{
    public List<string> Followers { get; set; } = new List<string>();
    public List<string> Following { get; set; } = new List<string>();
}