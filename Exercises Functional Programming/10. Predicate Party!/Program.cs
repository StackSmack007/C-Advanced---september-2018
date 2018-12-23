using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine().Split(' ').ToList();
        Predicate<string> predicate;

        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "Party!")
            {
                break;
            }
            string command = input[0];
            string condition = input[1];
            string value = input[2];
            predicate = GetPredicate(condition, value);
            if (command == "Remove")
            {
                guests.RemoveAll(predicate);
            }
            else
            {
                Queue<string> temp = new Queue<string>(guests.Count);
                foreach (var human in guests)
                {
                    temp.Enqueue(human);
                    if (predicate(human))
                    {
                        temp.Enqueue(human);
                    }
                }
                guests = temp.ToList();
            }
        }
        if (guests.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
            return;
        }
        Console.WriteLine("{0} are going to the party!", string.Join(", ", guests));
    }

    static Predicate<string> GetPredicate(string condition, string value)
    {
        if (condition == "StartsWith")
        {
            return p => p.StartsWith(value);
        }
        if (condition == "EndsWith")
        {
            return p => p.EndsWith(value);
        }
        return p => p.Length == int.Parse(value);
    }
}