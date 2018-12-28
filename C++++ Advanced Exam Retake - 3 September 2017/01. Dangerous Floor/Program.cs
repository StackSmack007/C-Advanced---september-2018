using System;
using System.Linq;
//16:25
class Program
{
    static void Main()
    {
        char[][] board = new char[8][];
        FillBoard(board);

        while (true)
        {
            string[] input = Console.ReadLine().Split('-');
            if (input[0] == "END")
            {
                break;
            }
            char figureType = input[0][0];

            int locRow = input[0][1] - '0';
            int locCol = input[0][2] - '0';

            int tarRow = input[1][0] - '0';
            int tarCol = input[1][1] - '0';

            if (!ValidateFigure(figureType, locRow, locCol, board))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }
            if (!ValidateMove(figureType,locRow,locCol,tarRow,tarCol))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }
            if (!ValidDestination(tarRow,tarCol))
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }
            board[locRow][locCol] = 'X';
            board[tarRow][tarCol] = figureType;
        }
    }

    static bool ValidateFigure(char figureType, int row, int col, char[][] jag)
    {
        if (jag[row][col] == figureType)
        {
            return true;
        }
        return false;
    }

    static bool ValidateMove(char figureType, int locRow, int locCol, int tarRow, int tarCol)
    {
        if (locRow == tarRow && locCol == tarCol)
        {
            return false;
        }
        switch (figureType)
        {
            case 'P':
                if (locCol == tarCol && locRow - 1 == tarRow)
                {
                    return true;
                }
                return false;
            case 'K':
                if (tarCol >= locCol - 1 && tarCol <= locCol + 1 &&
                    tarRow >= locRow - 1 && tarRow <= locRow + 1)
                {
                    return true;
                }
                return false;
            case 'B':
                if ((locCol - tarCol) * (locCol - tarCol) == (locRow - tarRow) * (locRow - tarRow))
                {
                    return true;
                }
                return false;
            case 'R':
                if (locRow==tarRow||locCol==tarCol)
                {
                    return true;
                }
                return false;
            case 'Q':
                if ((locRow == tarRow || locCol == tarCol)|| (locCol - tarCol) * (locCol - tarCol) == (locRow - tarRow) * (locRow - tarRow))
                {
                    return true;
                }
                return false;
        }
        return false;
    }

    static bool ValidDestination(int row, int col)
    {
        if (row >= 0 && row < 8 && col >= 0 && col < 8)
        {
            return true;
        }
        return false;
    }

    static void FillBoard(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            char[] input = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            jag[i] = input;
        }
    }
}//17:25