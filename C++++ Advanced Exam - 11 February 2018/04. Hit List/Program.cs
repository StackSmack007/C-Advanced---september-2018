using System;
using System.Collections.Generic;
class Program
{//13:15
    static void Main()
    {
        int requiredIndexInfo = int.Parse(Console.ReadLine());
        var nameInfos = new Dictionary<string, SortedDictionary<string, string>>();

        while (true)
        {
            string[] input = Console.ReadLine().Split('=');
            if (input[0] == "end transmissions")
            {
                break;
            }

            string name = input[0];
            string[] infos = input[1].Split(';');

            if (!nameInfos.ContainsKey(name))
            {
                nameInfos[name] = new SortedDictionary<string, string>();
            }

            foreach (var info in infos)
            {
                string[] infoData = info.Split(':');
                nameInfos[name][infoData[0]] = infoData[1];
            }
        }

        int indexCounter = 0;
        string targetName = Console.ReadLine().Substring(5);
        Console.WriteLine("Info on {0}:", targetName);

        foreach (var kvp in nameInfos[targetName])
        {
            Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            indexCounter += kvp.Key.Length + kvp.Value.Length;
        }

        Console.WriteLine($"Info index: {indexCounter}");

        if (indexCounter >= requiredIndexInfo)
        {
            Console.WriteLine("Proceed");
        }
        else
        {
            Console.WriteLine($"Need {requiredIndexInfo - indexCounter} more info.");
        }
    }
}//13:30