using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(' ');
        var filtersD = new Dictionary<string, Dictionary<string, Func<string, bool>>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(';');
            if (input[0] == "Print")
            {
                break;
            }
            string command = input[0];
            string filter = input[1];
            string value = input[2];

            Func<string, bool> funcCurrent = GetFunction(filter, value);

            if (!filtersD.ContainsKey(filter))
            {
                filtersD[filter] = new Dictionary<string, Func<string, bool>>();
            }
            if (command == "Add filter")
            {
                filtersD[filter][value] = funcCurrent; continue;
            }
            filtersD[filter].Remove(value);
        }
        Queue<string> result = new Queue<string>(names.Length);
        foreach (var name in names)
        {
            bool isValid = true;
            foreach (var DictRules in filtersD.Values)
            {
                foreach (var rule in DictRules.Values)
                {
                    if (rule(name))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (!isValid) break;
            }
            if (isValid)
            {
                result.Enqueue(name);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
    static Func<string, bool> GetFunction(string filter, string value)
    {
        if (filter == "Starts with")
        {
            return x => x.StartsWith(value);
        }
        else if (filter == "Ends with")
        {
            return x => x.EndsWith(value);
        }
        else if (filter == "Contains")
        {
            return x => x.Contains(value);
        }
        return x => x.Length == int.Parse(value);

    }
}