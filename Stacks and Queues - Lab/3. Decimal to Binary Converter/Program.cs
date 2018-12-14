using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number==0)
        {
            Console.WriteLine(0);
            return;
        }
        Stack<byte> result = new Stack<byte>();
        while (number != 0)
        {
            result.Push((byte)(number % 2));
            number /= 2;
        }
        while (result.Count > 0)
        {
            Console.Write(result.Pop());
        }
        Console.WriteLine();
    }
}