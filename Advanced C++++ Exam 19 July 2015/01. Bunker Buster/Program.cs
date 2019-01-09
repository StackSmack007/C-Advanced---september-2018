using System;
using System.Linq;
//17:00
class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine().Split(' ')[0]);
        int[][] bunkerCells = SetValues(rows);
        string input;
        while ((input = Console.ReadLine()) != "cease fire!")
        {
            string[] tokens = input.Split(' ');
            int row = int.Parse(tokens[0]);
            int col = int.Parse(tokens[1]);
            int power = char.Parse(tokens[2]);
            BombIt(bunkerCells, row, col, power);
        }
        int totalCellCount = bunkerCells.Sum(x => x.Count());
        int DeadCellCount = bunkerCells.Sum(x => x.Count(y => y <= 0));

        Console.WriteLine($"Destroyed bunkers: {DeadCellCount}");
        Console.WriteLine($"Damage done: {100.0*DeadCellCount / totalCellCount:F1} %");
    }
    static int[][] SetValues(int rows)
    {
        int[][] jag = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            jag[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        return jag;
    }

    static bool isInside(int[][] jag, int row, int col)
    {
        if (row >= 0 && col >= 0 && row < jag.Length && col < jag[0].Length)
        {
            return true;
        }
        return false;
    }

    static void BombIt(int[][] jag, int row, int col, int damage)
    {
        int halfDamage = (int)Math.Ceiling(damage / 2.0);
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (isInside(jag, i, j))
                {
                    if (i == row && j == col)
                    {
                        jag[i][j] -= (damage - halfDamage);
                    }
                    jag[i][j] -= halfDamage;
                }
            }
        }
    }
}
//17:30