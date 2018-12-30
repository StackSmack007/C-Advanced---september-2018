using System;
using System.Linq;
class Program
{//11:30
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        long bombValue = 0;
        int count = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Analyze")
            {
                break;
            }
            int[] bomb = input.Split(' ').Select(int.Parse).ToArray();
            if (IsValidBomb(bomb, size))
            {
                bombValue+=bomb[3];
                count++;
            }
        }
        Console.WriteLine(bombValue);
        Console.WriteLine(size*size*size-count);
    }
    static bool IsValidBomb(int[] coordinates, int size)
    {
        bool isInside = true;
        for (int i = 0; i < 3; i++)
        {
            if (coordinates[i] < 0 || coordinates[i] >= size|| coordinates[3] == 0)
            {
                isInside = false;
                break;
            }
        }
        return isInside;
    }
}//12:00