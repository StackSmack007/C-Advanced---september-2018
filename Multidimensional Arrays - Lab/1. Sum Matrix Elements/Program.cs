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
            int[] rowI = Console.ReadLine().Split(new char[]{' ',','},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < Math.Min(rowI.Length, matrixOfIntegers.GetLength(1)); j++)
            {
                matrixOfIntegers[i, j] = rowI[j];
                sum += rowI[j];
            }
        }
        Console.WriteLine(matrixOfIntegers.GetLength(0));
        Console.WriteLine(matrixOfIntegers.GetLength(1));
        //Console.WriteLine(matrixOfIntegers.Rank);
        Console.WriteLine(sum);
    }
}