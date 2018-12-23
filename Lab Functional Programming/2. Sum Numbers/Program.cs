using System;
using System.Linq;

class Program
{
    static void Main()
    {
        PrintCountSum(Console.ReadLine());
    }

    static Action<string> PrintCountSum = x => Console.WriteLine((x.Split(", ").Select(intParser).Count()) + "\n" + x.Split(", ").Select(intParser).Sum());

    static Func<string, int> intParser = x => int.Parse(x);
}