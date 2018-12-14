using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int sumPrimaryDiag = 0;
        int sumSecondaryDiag = 0;
        for (int i = 0; i < n; i++)
        {
            int[] rowArr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rowArr[j];
            }
            sumPrimaryDiag += matrix[i, i];
            sumSecondaryDiag += matrix[i, matrix.GetLength(1)-1 - i];
        }
        Console.WriteLine(Math.Abs(sumPrimaryDiag - sumSecondaryDiag));
    }
}