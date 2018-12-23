using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(GetMin(Console.ReadLine()));
    }
    static Func<string, int> GetMin = x => x.Split(' ').Select(int.Parse).OrderBy(z => z).First();
}