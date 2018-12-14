using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Int64[][] jagged = new Int64[n][];
        for (int i = 0; i < n; i++)
        {
            jagged[i] = new Int64[i + 1];

            jagged[i][0] = 1;
            jagged[i][jagged[i].Length - 1] = 1;
            if (jagged[i].Length == 1)
            {
                continue;
            }
            else
            {
                for (int j = 1; j < jagged[i].Length - 1; j++)
                {
                    jagged[i][j] = GetValueOrZero(i - 1, j, jagged) + GetValueOrZero(i - 1, j - 1, jagged);
                }
            }
        }
        foreach (var arr in jagged)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
    static Int64 GetValueOrZero(int row, int col, Int64[][] jar)
    {
        if (row < 0 || row >= jar.Length)
        {
            return 0;
        }
        else if (jar[row].Length > col && col >= 0)
        {
            return jar[row][col];
        }
        else
        {
            return 0;
        }
    }
}