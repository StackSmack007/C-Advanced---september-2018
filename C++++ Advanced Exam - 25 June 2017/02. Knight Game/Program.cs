using System;
//12:30

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[][] board = new char[size][];
        FillBoard(board);
        int counterOfRemovedKnights = 0;
        for (int power = 8; power >= 1; power--)
        {

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        if (EvaluatePower(row, col, board) == power)
                        {
                            counterOfRemovedKnights++;
                            board[row][col] = 'X';
                        }
                    }
                }
            }
        }
        Console.WriteLine(counterOfRemovedKnights);
    }
    static int EvaluatePower(int Row, int Col, char[][] jag)
    {
        return isInsideAndHasPower(jag, Row + 2, Col + 1) + isInsideAndHasPower(jag, Row + 2, Col - 1) +
               isInsideAndHasPower(jag, Row - 2, Col + 1) + isInsideAndHasPower(jag, Row - 2, Col - 1) +
               isInsideAndHasPower(jag, Row + 1, Col + 2) + isInsideAndHasPower(jag, Row - 1, Col + 2) +
               isInsideAndHasPower(jag, Row + 1, Col - 2) + isInsideAndHasPower(jag, Row - 1, Col - 2);
    }
    static int isInsideAndHasPower(char[][] jag, int row, int col)
    {
        if (row >= 0 && row < jag.Length && col >= 0 && col < jag[0].Length)
        {
            if (jag[row][col] == 'K')
            {
                return 1;
            }
        }
        return 0;
    }
    static void FillBoard(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            var input = Console.ReadLine().ToCharArray();
            board[i] = input;
        }
    }
}
//13:00