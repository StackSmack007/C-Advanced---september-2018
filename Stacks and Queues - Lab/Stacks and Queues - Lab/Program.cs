using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<char> result = new Stack<char>();
        foreach (char letter in input)
        {
            result.Push(letter);
        }
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(result.Pop());
        }
        Console.WriteLine();
    }
}