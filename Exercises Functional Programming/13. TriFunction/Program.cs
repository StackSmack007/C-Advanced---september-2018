using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int sumToCheck = int.Parse(Console.ReadLine());
        string[] namesArr = Console.ReadLine().Split(' ');
        Console.WriteLine(GetName(namesArr,sumToCheck,IsCorrect));
    }

    static Func<string[], int, Func<string, int, bool>,string> GetName = (x, y, Z) => x.FirstOrDefault(m => Z(m, y));

    static Func<string, int, bool> IsCorrect = (name, y) => name.Sum(n => n) >= y;
}