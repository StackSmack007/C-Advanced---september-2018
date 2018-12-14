using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[][] matrix = new int[size[0]][];
        for (int i = 0; i < size[0]; i++)
        {
            matrix[i] = new int[size[1]];
            for (int j = 0; j < size[1]; j++)
            {
                if (i == 0 && j == 0)
                {
                    matrix[0][0] = 1;
                }
                else if (j == 0)
                {
                    matrix[i][j] = matrix[i - 1][size[1] - 1] + 1;
                }
                else
                {
                    matrix[i][j] = matrix[i][j - 1] + 1;
                }
            }
        }
        int commandsNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsNumber; i++)
        {
            string[] commandRow = Console.ReadLine().Split(' ');
            string command = commandRow[1];
            if (command == "up" || command == "down")
            {
                int column = int.Parse(commandRow[0]);
                int positions = int.Parse(commandRow[2]) % size[0];
                if (command == "up")
                {
                    if (positions > size[0] / 2)
                    {
                        positions = size[0] - positions;
                        GoDown(matrix, column, positions);
                    }
                    else
                    {
                        GoUp(matrix, column, positions);
                    }
                }
                else
                {
                    if (positions > size[0] / 2)
                    {
                        positions = size[0] - positions;
                        GoUp(matrix, column, positions);
                    }
                    else
                    {
                        GoDown(matrix, column, positions);
                    }
                }
            }
            if (command == "left" || command == "right")
            {
                int row = int.Parse(commandRow[0]);
                int positions = int.Parse(commandRow[2]) % size[1];
                if (command == "left")
                {
                    if (positions > size[0] / 2)
                    {
                        positions = size[1] - positions;
                        GoRight(matrix, row, positions);
                    }
                    else
                    {
                        GoLeft(matrix, row, positions);
                    }
                }
                else
                {
                    if (positions > size[0] / 2)
                    {
                        positions = size[1] - positions;
                        GoLeft(matrix, row, positions);
                    }
                    else
                    {
                        GoRight(matrix, row, positions);
                    }
                }
            }
        }
        ushort num = 0;
        for (int i = 0; i < size[0]; i++)
        {
            for (int j = 0; j < size[1]; j++)
            {
                num++;
                if (matrix[i][j] == num)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    int[] start = { i, j };
                    int[] end = FindIndex(num, matrix);
                    Console.WriteLine("Swap ({0}) with ({1})", string.Join(", ", start), string.Join(", ", end));
                    int temp = matrix[start[0]][start[1]];
                    matrix[start[0]][start[1]] = matrix[end[0]][end[1]];
                    matrix[end[0]][end[1]] = temp;
                }
            }
        }
    }
    static void GoDown(int[][] matrix, int col, int positions)
    {
        for (int j = 0; j < positions; j++)
        {
            int last = matrix[matrix.Length - 1][col];
            for (int k = matrix.GetLength(0) - 1; k > 0; k--)
            {
                matrix[k][col] = matrix[k - 1][col];
            }
            matrix[0][col] = last;
        }
    }
    static void GoUp(int[][] matrix, int col, int positions)
    {
        for (int j = 0; j < positions; j++)
        {
            int first = matrix[0][col];
            for (int k = 0; k < matrix.Length - 1; k++)
            {
                matrix[k][col] = matrix[k + 1][col];
            }
            matrix[matrix.GetLength(0) - 1][col] = first;
        }
    }
    static void GoRight(int[][] matrix, int row, int positions)
    {
        for (int j = 0; j < positions; j++)
        {
            int last = matrix[row][matrix[row].Length - 1];
            for (int k = matrix[row].Length - 1; k > 0; k--)
            {
                matrix[row][k] = matrix[row][k - 1];
            }
            matrix[row][0] = last;
        }
    }
    static void GoLeft(int[][] matrix, int row, int positions)
    {
        for (int j = 0; j < positions; j++)
        {
            int first = matrix[row][0];
            for (int k = 0; k < matrix[row].Length - 1; k++)
            {
                matrix[row][k] = matrix[row][k + 1];
            }
            matrix[row][matrix[row].Length - 1] = first;
        }
    }
    static int[] FindIndex(ushort num, int[][] mtrx)
    {
        for (int i = 0; i < mtrx.Length; i++)
        {
            for (int j = 0; j < mtrx[i].Length; j++)
            {
                if (mtrx[i][j] == num)
                {
                    return new int[2] { i, j };
                }
            }
        }
        return new int[2] { -1, -1 };
    }
}