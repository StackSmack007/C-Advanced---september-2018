using System;
using System.Collections.Generic;
using System.Linq;
class Program
    //14:25
{
    static void Main()
    {
        Dictionary<string, List<Jahnre>> nameFields = new Dictionary<string, List<Jahnre>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '-', '>' },StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "end")
            {
                break;
            }
            if (input[0] == "ban")
            {
                string targetName = input[1];
                if (nameFields.ContainsKey(targetName))
                {
                    nameFields.Remove(targetName);
                }
                continue;
            }
            string name = input[0];
            string jahnre = input[1];
            int likes = int.Parse(input[2]);
            Jahnre currentJanre = new Jahnre
            {
                JahnreName = jahnre,
                Likes = likes
            };
            if (!nameFields.ContainsKey(name))
            {
                nameFields[name] = new List<Jahnre> { currentJanre };
                continue;
            }
            int indexOfJahnre = nameFields[name].FindIndex(x => x.JahnreName == jahnre);
            if (indexOfJahnre == -1)
            {
                nameFields[name].Add(currentJanre);
            }
            else
            {
                nameFields[name][indexOfJahnre].Likes += likes;
            }
        }
        foreach (var kvp in nameFields.OrderByDescending(x => x.Value.Sum(y => y.Likes)).ThenBy(x => x.Value.Count))
        {
            Console.WriteLine(kvp.Key);
            foreach (Jahnre topic in kvp.Value)
            {
                Console.WriteLine($"- {topic.JahnreName}: {topic.Likes}");
            }
        }
    }
}
class Jahnre
{
    public string JahnreName { get; set; }
    public int Likes { get; set; }
}
//14:58