using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Action HonorableMention = () => Console.WriteLine("Sir "+string.Join("\nSir ",Console.ReadLine().Split(' ')));

        HonorableMention();
    }
}