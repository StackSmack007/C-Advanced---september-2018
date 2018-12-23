using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var result = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(w => char.IsUpper(w[0]));
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}