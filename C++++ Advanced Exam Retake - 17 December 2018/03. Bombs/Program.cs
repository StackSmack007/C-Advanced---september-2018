using System;
using System.Collections.Generic;
using System.Linq;
//11:15
class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[][] jagArr = new int[size][];
        Fill(jagArr);
        HashSet<string> bombs = Console.ReadLine().Split(' ').ToHashSet<string>();
        foreach (string bomb in bombs)
        {
            Boom(jagArr, bomb);
        }
        Console.WriteLine("Alive cells: {0}", CountAndSumOfNotNullElements(jagArr)[0]);
        Console.WriteLine("Sum: {0}", CountAndSumOfNotNullElements(jagArr)[1]);
        Print(jagArr);
    }
    static void Fill(int[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            jag[i] = row;
        }
    }

    static void Boom(int[][] jag, string bomb)
    {
        int[] rowColBomb = bomb.Split(',').Select(int.Parse).ToArray();
        int rowB = rowColBomb[0];
        int colB = rowColBomb[1];
        int damg = jag[rowB][colB];

        int startRow = Math.Max(0, rowB - 1);
        int endRow = Math.Min(jag.Length - 1, rowB + 1);
        int startCol = Math.Max(0, colB - 1);
        int endCol = Math.Min(jag[0].Length - 1, colB + 1);
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (jag[i][j] > 0)
                {
                    jag[i][j] -= damg;
                }
            }
        }
    }

    static void Print(int[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    static int[] CountAndSumOfNotNullElements(int[][] jag)
    {
        int count = 0;
        int sum = 0;
        for (int i = 0; i < jag.Length; i++)
        {
            count += jag[i].Where(x => x > 0).Count();
            sum += jag[i].Where(x => x > 0).Sum();
        }
        return new int[] { count, sum };
    }
}
//11:45 90/100