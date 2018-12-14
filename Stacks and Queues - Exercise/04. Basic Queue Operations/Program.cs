using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] rowArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Queue<int> rowQueue = new Queue<int>(rowArray);
        for (int i = 0; i < input[1]; i++)
        {
            rowQueue.Dequeue();
        }
        if (rowQueue.Count()==0)
        {
            Console.WriteLine(0); return;
        }
        if (rowQueue.Contains(input[2]))
        {
            Console.WriteLine("true");
        }
        else
        {
            int minNumber = int.MaxValue;
            while (rowQueue.Count>0)
            {
                minNumber = Math.Min(minNumber, rowQueue.Dequeue());
            }
            Console.WriteLine(minNumber);
        }
    }
}