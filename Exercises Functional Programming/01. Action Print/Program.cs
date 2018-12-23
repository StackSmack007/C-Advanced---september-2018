using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Action PrintRow = () =>
        {
            foreach (var word in Console.ReadLine().Split(' '))
            {
                Console.WriteLine(word);
            }
        };
        PrintRow();
    }
}