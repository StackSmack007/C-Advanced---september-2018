using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
        var result = GetNumbers(number, numbers);
        Console.WriteLine(string.Join(" ", result));
    }

   private static List<int> GetNumbers(int number, int[] divisors)
    {
        List<int> result = new List<int>();
        for (int i = 1; i <= number; i++)
        {      
            bool isValid = true;

            foreach (var d in divisors)
            {
                Predicate<int> uncleanCut = x => i % x != 0;
                if (uncleanCut(d))
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                result.Add(i);
            }
        }
        return result;
    }
}