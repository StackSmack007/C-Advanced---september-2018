using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int squereSize = 2;
        char[,] matrix = new char[size[0], size[1]];
        for (int i = 0; i < size[0]; i++)
        {
            char[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = inputRow[j];
            }
        }
        int countOfEquals = 0;
        for (int i = 0; i <= size[0] - squereSize; i++)
        {
            for (int j = 0; j <= size[1] - squereSize; j++)
            {
                bool allEqual = true;
                char firstOne = matrix[i, j];
                for (int row = i; row < i + squereSize; row++)
                {
                    for (int col = j; col < j + squereSize; col++)
                    {
                        if (matrix[row, col] != firstOne)
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (!allEqual)
                    {
                        break;
                    }
                }
                if (allEqual)
                {
                    countOfEquals++;
                }
            }
        }
        Console.WriteLine(countOfEquals);
    }
}