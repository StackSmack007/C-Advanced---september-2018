using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int rowsN = int.Parse(Console.ReadLine());
        int[][] jagged = new int[rowsN][];
        for (int i = 0; i < jagged.Length; i++)
        {
            jagged[i] = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "END")
            {
                break;
            }
            string command = input[0];
            int rowIndex = int.Parse(input[1]);
            int colIndex = int.Parse(input[2]);
            int value = int.Parse(input[3]);
            if (!IsCoordinatesValid(jagged, rowIndex, colIndex))
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }
            if (command == "Add")
            {
                jagged[rowIndex][colIndex] += value;
            }
            else if (command == "Subtract")
            {
                jagged[rowIndex][colIndex] -= value;
            }
        }
        foreach (var array in jagged)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
    static bool IsCoordinatesValid(int[][] jag, int r, int c)
    {
        if (r < jag.Length & r >= 0)
        {
            if (c < jag[r].Length & c >= 0)
            {
                return true;
            }
        }
        return false;
    }
}