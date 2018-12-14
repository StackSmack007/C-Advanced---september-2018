using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int squereSize = 3;
        int[,] matrix = new int[size[0], size[1]];
        for (int i = 0; i < size[0]; i++)
        {
            int[] inputRow = Console.ReadLine()
                .Split(' ', StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = inputRow[j];
            }
        }
        int[] RowColAndsumOfSubMatrix = { 0, 0, int.MinValue };
        for (int i = 0; i <= size[0] - squereSize; i++)
        {
            for (int j = 0; j <= size[1] - squereSize; j++)
            {
                int localSum = 0;
                for (int row = i; row < i + squereSize; row++)
                {
                    for (int col = j; col < j + squereSize; col++)
                    {
                        localSum += matrix[row, col];
                    }
                }
                if (localSum > RowColAndsumOfSubMatrix[2])
                {
                    RowColAndsumOfSubMatrix[0] = i;
                    RowColAndsumOfSubMatrix[1] = j;
                    RowColAndsumOfSubMatrix[2] = localSum;
                }
            }
        }
        Console.WriteLine("Sum = " + RowColAndsumOfSubMatrix[2]);
        for (int i = RowColAndsumOfSubMatrix[0]; i < RowColAndsumOfSubMatrix[0] + squereSize; i++)
        {
            for (int j = RowColAndsumOfSubMatrix[1]; j < RowColAndsumOfSubMatrix[1] + squereSize; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}