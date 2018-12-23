using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int allowedLength = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(' ');
        Action<int, string[]> PrintSelected = (x, y) => Console.WriteLine(string.Join("\n", y.Where(n => n.Length <= x)));
        PrintSelected(allowedLength, names);
    }
}