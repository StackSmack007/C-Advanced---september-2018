using System;
using System.Linq;

class Program
{
    static void Main()
    {

        int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int[] submatrixSize = { 2, 2 };//Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        if (submatrixSize[0] > size[0] || submatrixSize[1] > size[1])
        {
            Console.WriteLine("Invalid submatrix Size");
            return;
        }
        int[,] matrix = new int[size[0], size[1]];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] rowI = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < Math.Min(rowI.Length, matrix.GetLength(1)); j++)
            {
                matrix[i, j] = rowI[j];
            }
        }
        int[] StartIndexAndSum = { 0, 0, int.MinValue };
        for (int row = 0; row <= matrix.GetLength(0) - submatrixSize[0]; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - submatrixSize[1]; col++)
            {
                int sum = 0;
                for (int i = 0; i < submatrixSize[0]; i++)
                {
                    for (int j = 0; j < submatrixSize[1]; j++)
                    {
                        sum += matrix[row + i, col + j];
                    }
                }
                if (sum > StartIndexAndSum[2])
                {
                    StartIndexAndSum = new int[] { row, col, sum };
                }
            }
        }
        for (int row = StartIndexAndSum[0]; row < StartIndexAndSum[0] + submatrixSize[0]; row++)
        {
            for (int col = StartIndexAndSum[1]; col < StartIndexAndSum[1] + submatrixSize[1]; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(StartIndexAndSum[2]);
    }
}