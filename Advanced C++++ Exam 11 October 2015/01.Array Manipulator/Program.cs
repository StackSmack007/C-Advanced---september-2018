using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> numbers = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));

        while (true)
        {
            string[] input = Console.ReadLine().ToLower().Split(' ');
            if (input[0] == "end")
            {
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
                break;
            }
            if (input[0] == "exchange")
            {
                int index = int.Parse(input[1]);
                if (index < 0 || index >= numbers.Count())
                {
                    Console.WriteLine("Invalid index");
                    continue;
                }
                for (int i = 0; i <= index; i++)
                {
                    numbers.Enqueue(numbers.Dequeue());
                }
            }
            if ((input[1] == "odd" && !numbers.Any(x => x % 2 != 0)) || (input[1] == "even" && !numbers.Any(x => x % 2 == 0)))
            {
                Console.WriteLine("No matches");
                continue;
            }
            if (input[0] == "max")
            {
                int maxNumber = numbers.Where(x => input[1] == "even" ? x % 2 == 0 : x % 2 != 0).Max();
                int index = numbers.ToList().FindLastIndex(x => x == maxNumber);
                Console.WriteLine(index);
            }
            if (input[0] == "min")
            {
                int minNumber = numbers.Where(x => input[1] == "even" ? x % 2 == 0 : x % 2 != 0).Min();
                int index = numbers.ToList().FindLastIndex(x => x == minNumber);
                Console.WriteLine(index);
            }
            if (input[0] == "first" || input[0] == "last")
            {
                string oddOrEven = input[2];
                int countAvailable = numbers.Count(x => oddOrEven == "even" ? x % 2 == 0 : x % 2 != 0);
                int countDemanded = int.Parse(input[1]);
                if (countDemanded > numbers.Count)
                {
                    Console.WriteLine("Invalid count");
                    continue;
                }
                if (input[0] == "first")
                {
                    int[] result = numbers.Where(x => oddOrEven == "even" ? x % 2 == 0 : x % 2 != 0).Take(countDemanded).ToArray();
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
                else
                {
                    int[] result = numbers.Reverse().Where(x => oddOrEven == "even" ? x % 2 == 0 : x % 2 != 0).Take(countDemanded).Reverse().ToArray();
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
            }
        }
    }
}