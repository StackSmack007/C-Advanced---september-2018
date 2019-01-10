using System;
using System.Collections.Generic;
using System.Linq;
//11:00
class Program
{
    static void Main()
    {
        string[] array = Console.ReadLine().Split(' ');
        string[] input;
        while ((input = Console.ReadLine().Split(' '))[0] != "end")
        {
            string command = input[0];
            if (command.Substring(0, 4) == "roll")
            {
                var times = int.Parse(input[1]) % array.Length;
                if (times < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }
                if (command == "rollRight")
                {
                    times = -times + array.Length;  //Allows using RollLeft with the same outcome
                }
                RollLeft(array, times);
            }

            if (command == "reverse" || command == "sort")
            {
                int startIndex = int.Parse(input[2]);
                int count = int.Parse(input[4]);

                if (startIndex < 0 || startIndex >= array.Length || count + startIndex > array.Length || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }
                List<string> beggining = array.Take(startIndex).ToList();
                List<string> core = array.Skip(startIndex).Take(count).ToList();
                if (command == "reverse")
                {
                    core.Reverse();
                }
                else
                {
                    core = core.OrderBy(x => x).ToList();
                }
                List<string> end = array.Skip(startIndex + count).ToList();
                beggining.AddRange(core);
                beggining.AddRange(end);
                array = beggining.ToArray();
            }
        }
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
    static void RollLeft(string[] arr, int count)
    {
        for (int c = 0; c < count; c++)
        {
            string firstElement = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    arr[i] = firstElement;
                    break;
                }
                arr[i] = arr[i + 1];
            }
        }
    }
}//11:45