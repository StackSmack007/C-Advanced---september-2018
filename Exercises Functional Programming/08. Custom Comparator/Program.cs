using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<int, int, int> checker = (a, b) => 
        (a % 2 != 0 && b % 2 == 0) ? 1 :
        (a % 2 == 0 && b % 2 != 0) ? -1 :
        a > b ? 1 : -1;
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(array, new Comparison<int>(checker));
        Console.WriteLine(string.Join(" ", array));
    }
}