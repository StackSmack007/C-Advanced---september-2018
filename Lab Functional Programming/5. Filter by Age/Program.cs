using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        List<KeyValuePair<string, int>> nameAge = new List<KeyValuePair<string, int>>();
        //Dictionary<string, int> nameAge = new Dictionary<string, int>();
        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split(", ");
            nameAge.Add(new KeyValuePair<string, int>(input[0], int.Parse(input[1])));
        }
        string youngerOrOlder = Console.ReadLine();
        int ageLimit = int.Parse(Console.ReadLine());
        string whatToPrint = Console.ReadLine();
        Print(nameAge, youngerOrOlder, ageLimit, whatToPrint, filtherAge);
    }
    static Func<List<KeyValuePair<string, int>>, string, int, List<KeyValuePair<string, int>>> filtherAge = (list, yo, age) =>
               {
                   return list.Where(x => yo == "younger" ? x.Value < age : x.Value >= age).ToList();
               };

    static void Print(List<KeyValuePair<string, int>> people, string yangerOrOlder, int ageLimit, string whatToPrint, Func<List<KeyValuePair<string, int>>, string, int, List<KeyValuePair<string, int>>> filter)
    {
       var newList = new List<KeyValuePair<string, int>> (filter(people, yangerOrOlder, ageLimit));
        if (whatToPrint == "name")
        {
            foreach (var kvp in newList)
            {
                Console.WriteLine(kvp.Key);
            }
        }
        else if (whatToPrint == "age")
        {
            foreach (var kvp in newList)
            {
                Console.WriteLine(kvp.Value);
            }
        }
        else
        {
            foreach (var kvp in newList)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }
}