using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        string[,] matrix = new string[size[0], size[1]];
        for (int i = 0; i < size[0]; i++)
        {
            char firstLast = (char)('a' + i);
            for (int j = 0; j < size[1]; j++)
            {
                char middle = (char)(firstLast + j);
                string current = "" + firstLast + middle + firstLast;
                Console.Write(current+" ");
            }
            Console.WriteLine();
        }
    }
}