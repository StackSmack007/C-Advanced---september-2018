using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string input= Console.ReadLine();
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join(" ", input.Split(' ').Select(int.Parse).Where(x => x % number != 0).Reverse()));
    }
}
