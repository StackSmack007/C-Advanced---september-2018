using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] arrayOfNumbers = Console.ReadLine().Split(' ');
        Dictionary<string, int> numbersCount = new Dictionary<string, int>();
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (!numbersCount.ContainsKey(arrayOfNumbers[i]))
            {
                numbersCount[arrayOfNumbers[i]] = 1;
            }
            else
            {
                numbersCount[arrayOfNumbers[i]] ++;
            }
        }
        foreach (var kvp in numbersCount)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
        }
    }
}