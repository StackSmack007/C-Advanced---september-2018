using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        Stack<int> numbers = new Stack<int>();
        for (int i = 0; i < input.Length; i++)
        {
            int number = 0;
            if (input[i] == "-")
            {
                number = -int.Parse(input[i + 1]);
                i++;
            }
            else if (input[i] == "+")
            {
                number = int.Parse(input[i + 1]);
                i++;
            }
            else
            {
                number = int.Parse(input[i]);
            }
            numbers.Push(number);
        }
        int result = 0;
        while (numbers.Count > 0)
        {
            result += numbers.Pop();
        }
        Console.WriteLine(result);
    }
}