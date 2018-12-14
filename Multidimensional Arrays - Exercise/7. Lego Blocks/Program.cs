using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int pieceRows = int.Parse(Console.ReadLine());
        int[][] jag1 = new int[pieceRows][];
        int[][] jag2 = new int[pieceRows][];
        FillJaggedArray(jag1, false);
        FillJaggedArray(jag2, true);
        int sizeConst = jag1[0].Length + jag2[0].Length;
        for (int i = 0; i < pieceRows; i++)
        {
            if (sizeConst != jag1[i].Length + jag2[i].Length)
            {
                Console.WriteLine($"The total number of cells is: {GetCountOfElements(jag1) + GetCountOfElements(jag2)}");
                return;
            }
        }

        int[][] result = new int[pieceRows][];
        for (int i = 0; i < pieceRows; i++)
        {
            result[i] = new int[sizeConst];
            for (int j = 0; j < sizeConst; j++)
            {
                if (j < jag1[i].Length)
                {
                    result[i][j] = jag1[i][j];
                }
                else
                {
                    result[i][j] = jag2[i][j - jag1[i].Length];
                }
            }
        }

        PrintMatrix(result);
    }
    static void FillJaggedArray(int[][] jag, bool Reversed)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            int[] inputLine = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if (Reversed)
            {
                Array.Reverse(inputLine);
            }
            jag[i] = inputLine;
        }
    }

    static void PrintMatrix(int[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            Console.WriteLine($"[{string.Join(", ", jag[i])}]");
        }
    }

    static int GetCountOfElements(int[][] jag)
    {
        int count = 0;
        for (int i = 0; i < jag.Length; i++)
        {
            count += jag[i].Length;
        }
        return count;
    }
}