using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(',').Select(x=>x.Trim()).Select(int.Parse).ToArray();
        int n = 3;
        int[][] jag = new int[n][];
        for (int i = 0; i < n; i++)
        {
            List<int> commonNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (Math.Abs(number)%n==i)
                {
                    commonNumbers.Add(number);
                }
            }
            jag[i] = commonNumbers.ToArray();
        }
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}