using System;
using System.Linq;

class Program
    {
        static void Main()
        {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int diagSum = 0;
        for (int i = 0; i < n; i++)
        {
            int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = row[j];
                if (i==j)
                {
                    diagSum += row[j];
                }
            }
        }
        Console.WriteLine(diagSum);
        }
    }