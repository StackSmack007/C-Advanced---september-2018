using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int operationsN = int.Parse(Console.ReadLine());
        Stack<char> text = new Stack<char>();
        Stack<char[]> saves = new Stack<char[]>();
        for (int i = 0; i < operationsN; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "4")
            {
                char[] arr = saves.Pop();
                Array.Reverse(arr);
                text = new Stack<char>(arr);
            }
            switch (input[0])
            {
                case "1":
                    saves.Push(text.ToArray());
                    foreach (char letter in input[1])
                    {
                        text.Push(letter);
                    }
                    break;
                case "2":
                    saves.Push(text.ToArray());
                    for (int j = 0; j < int.Parse(input[1]); j++)
                    {
                        text.Pop();
                    }
                    break;
                case "3":
                    var arr = text.ToArray();
                    Array.Reverse(arr);
                    Console.WriteLine(arr[int.Parse(input[1]) - 1]);
                    break;
            }
        }
    }
}