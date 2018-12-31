using System;
using System.Linq;
//18:00
class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[][] board = new int[size[0]][];
        Create(board, size);
        long score = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Let the Force be with you")
            {
                break;
            }
            int[] playerBasePoint = input.Split(' ').Select(int.Parse).ToArray();
            int[] evilBasePoint = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Nullify(board, evilBasePoint);
            score += CollectCells(board, playerBasePoint);

        }
        Console.WriteLine(score);
    }

    static void Create(int[][] jag, int[] size)
    {
        int counterCells = 0;
        for (int i = 0; i < jag.Length; i++)
        {
            jag[i] = new int[size[1]];
            for (int j = 0; j < size[1]; j++)
            {
                jag[i][j] = counterCells++;
            }
        }
    }

    static void Nullify(int[][] jag, int[] evilPoint)
    {
        int row = evilPoint[0];
        int col = evilPoint[1];
        int subtractor = 0;
        if (row > jag.Length)
        {
            subtractor = row - jag.Length + 1;
            row -= subtractor;
            col -= subtractor;
        }
        if (col > jag[0].Length)
        {
            subtractor = col - jag[0].Length + 1;
            row -= subtractor;
            col -= subtractor;
        }

        while (row >= 0 && col >= 0)
        {
            if (isInsideTheMatrix(jag.Length, jag[0].Length, row, col))
            {
                jag[row][col] = 0;
            }
            row--;
            col--;
        }
    }

    static long CollectCells(int[][] jag, int[] basePoint)
    {
        long result = 0;
        int row = basePoint[0];
        int col = basePoint[1];
        int subtractor = 0;
        if (row > jag.Length)
        {
            subtractor = row - jag.Length + 1;
            row -= subtractor;
            col += subtractor;
        }
       if (col<0)
       {
           subtractor = -(1+col);
           row -= subtractor;
           col += subtractor;
       }

        while (row >= 0 && col < jag[0].Length)
        {
            if (isInsideTheMatrix(jag.Length, jag[0].Length, row, col))
            {
                result += jag[row][col];
            }
            row--;
            col++;
        }
        return result;
    }

    static bool isInsideTheMatrix(int rowsCount, int colsCount, int row, int col)
    {
        if (row >= 0 && row < rowsCount && col >= 0 && col < colsCount)
        {
            return true;
        }
        return false;
    }
}//20:00