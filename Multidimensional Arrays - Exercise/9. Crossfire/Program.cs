using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string[][] jaggedArray = new string[size[0]][];
        int num = 1;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            jaggedArray[i] = new string[size[1]];
            for (int j = 0; j < size[1]; j++)
            {
                jaggedArray[i][j] = "" + num++;
            }
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Nuke it from orbit")
            {
                break;
            }
            int[] array = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = array[0];
            int col = array[1];
            int range = array[2];

            if ((row >= jaggedArray.Length || row < 0)
               && (col < 0 || col > size[1]))
            {
                continue;
            }
            BombIt(jaggedArray, row, col, range, "*");
            jaggedArray = Reform(jaggedArray, "*");
        }
        Print(jaggedArray);
    }
    static void Print(string[][] jag)
    {
        foreach (var rowArr in jag)
        {
            Console.WriteLine(string.Join(" ", rowArr));
        }
    }

    static void BombIt(string[][] jag, int CenterRow, int CenterCol, int Range, string symbol)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if ((i == CenterRow && j >= CenterCol - Range && j <= CenterCol + Range)
                    ||(j == CenterCol && i >= CenterRow - Range && i <= CenterRow + Range))
                {
                    jag[i][j] = symbol;
                }
            }
        }
    }

    static string[][] Reform(string[][] jag, string symbol)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            jag[i] = jag[i].Where(x => x != symbol).ToArray();
        }
        return jag.Where(x => x.Length > 0).ToArray();
    }
}