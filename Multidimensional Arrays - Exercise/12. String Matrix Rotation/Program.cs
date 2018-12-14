using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int turnsClockWise = (int.Parse(Console.ReadLine().Substring(7).TrimEnd(')')) / 90) % 4;
        Queue<string> inputLines = new Queue<string>();
        short maxLength = -1;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            if (input.Length > maxLength)
            {
                maxLength = (short)input.Length;
            }
            inputLines.Enqueue(input);
        }
        char[][] jagResult = MakeMatrix(inputLines, maxLength);
        for (int i = 0; i < turnsClockWise; i++)
        {
            jagResult= RotateJag(jagResult);
        }
        PrintJag(jagResult);
    }

    static char[][] MakeMatrix(Queue<string> storage, int maxLength)
    {
        char[][] matrix = new char[storage.Count][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = storage.Dequeue().PadRight(maxLength, ' ').ToCharArray();
        }
        return matrix;
    }

    static char[][] RotateJag(char[][] jag)
    {
        char[][] temp = new char[jag[0].Length][];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = new char[jag.Length];
            for (int j = 0; j < jag.Length; j++)
            {
                temp[i][j] = jag[j][i];
            }
            Array.Reverse(temp[i]);
        }
return temp;
    }

    static void PrintJag(char[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }
}