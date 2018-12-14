using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = input[j];
            }
        }
        char symbol = char.Parse(Console.ReadLine());
        int row = -1;
        int col = -1;
        for (int i = 0; i < n; i++)
        {
            bool isFound = false;
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == symbol)
                {
                    row = i;
                    col = j;
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {
                break;
            }
        }
        if (row == -1)
        {
            Console.WriteLine("{0} does not occur in the matrix", symbol);
        }
        else
        {
            Console.WriteLine($"({row}, {col})");
        }
    }
}