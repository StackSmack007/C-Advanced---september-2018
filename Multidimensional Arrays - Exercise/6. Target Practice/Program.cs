using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[] snakeInput = Console.ReadLine().ToCharArray();
        Queue<char> snake = new Queue<char>(snakeInput);
        char[][] stairs = new char[size[0]][];

        for (int row = stairs.Length - 1; row >= 0; row--)
        {
            stairs[row] = new char[size[1]];
            if (row == stairs.Length - 1 || ((stairs.Length - 1) - row) % 2 == 0)
            {
                for (int col = stairs[row].Length - 1; col >= 0; col--)
                {
                    stairs[row][col] = snake.Peek();
                    snake.Enqueue(snake.Dequeue());
                }
            }
            else
            {
                for (int col = 0; col < stairs[row].Length; col++)
                {
                    stairs[row][col] = snake.Peek();
                    snake.Enqueue(snake.Dequeue());
                }
            }
        }

        int[] commandLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rowShot = commandLine[0];
        int colShot = commandLine[1];
        int damageR = commandLine[2];

        Destroy(stairs, rowShot, colShot, damageR, ' ');
        Gravity(stairs, ' ');
        PrintJaggedArray(stairs);
    }

    static void PrintJaggedArray(char[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }

    static void Destroy(char[][] jag, int centerRow, int centerCol, int damageR, char symbol)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (((centerRow-i)* (centerRow - i)+ (centerCol - j)* (centerCol - j))<=damageR*damageR)
                {
                    jag[i][j] = symbol;
                } 
            }
        }
    }
    static void Gravity(char[][] jag, char symbol)
    {
        for (int i = 0; i < jag.Length - 1; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] != symbol & jag[i + 1][j] == symbol)
                {
                    jag[i + 1][j] = jag[i][j];
                    jag[i][j] = symbol;
                    i = -1;
                    break;
                }
            }
        }
    }
}