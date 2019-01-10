using System;
using System.Collections.Generic;
using System.Linq;

//17:10
class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[][] stairs = new char[size[0]][];
        string word = Console.ReadLine();
        Fill(stairs, size[1], word);
        int[] shot = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        MakeWhole(stairs, shot);
        FallDown(stairs);
        PrintStairs(stairs);
    }

    static void Fill(char[][] jag, int cols, string word)
    {
        Queue<char> wordQueue = new Queue<char>(word);
        for (int i = jag.Length-1; i >= 0; i--)
        {
            jag[i] = new char[cols];

            if ((jag.Length-1-i) % 2 == 0)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    jag[i][j] = wordQueue.Peek();
                    wordQueue.Enqueue(wordQueue.Dequeue());
                }
            }
            else
            {
                for (int j = 0; j < cols; j++)
                {
                    jag[i][j] = wordQueue.Peek();
                    wordQueue.Enqueue(wordQueue.Dequeue());
                }
            }
        }
    }

    static void MakeWhole(char[][] jag, int[] shot)
    {
        int row = shot[0];
        int col = shot[1];
        int radius = shot[2];
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                int distancePowered2 = (row - i) * (row - i) + (col - j) * (col - j);
                if (distancePowered2 <= radius * radius)
                {
                    jag[i][j] = ' ';
                }
            }
        }
    }

    static void FallDown(char[][] jag)
    {
        for (int i = 0; i < jag.Length - 1; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] != ' ' & jag[i + 1][j] == ' ')
                {
                    jag[i + 1][j] = jag[i][j];
                    jag[i][j] = ' ';
                    i = -1;
                    break;
                }
            }
        }
    }

    static void PrintStairs(char[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }
}//17:40