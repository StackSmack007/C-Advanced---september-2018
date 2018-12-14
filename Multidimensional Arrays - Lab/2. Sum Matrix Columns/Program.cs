using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int[,] matrixOfIntegers = new int[size[0], size[1]];
        int sum = 0;
        for (int i = 0; i < matrixOfIntegers.GetLength(0); i++)
        {
            int[] rowI = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < Math.Min(rowI.Length, matrixOfIntegers.GetLength(1)); j++)
            {
                matrixOfIntegers[i, j] = rowI[j];
                sum += rowI[j];
            }
        }
        int[] sumsOfCollumns = new int[matrixOfIntegers.GetLength(1)];
        for (int col = 0; col < matrixOfIntegers.GetLength(1); col++) //колони
        {
            for (int row = 0; row < matrixOfIntegers.GetLength(0); row++)//редове
            {
                sumsOfCollumns[col] += matrixOfIntegers[row, col];
            }
        }

        foreach (var item in sumsOfCollumns)
        {
            Console.WriteLine(item);
        }
    }
}