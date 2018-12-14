using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> indexesOfOpeningBrackets = new Stack<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                indexesOfOpeningBrackets.Push(i);
            }
            else if (input[i] == ')')
            {
                int openingIndex = indexesOfOpeningBrackets.Pop();
                int closingIndex = i;
                for (int j = openingIndex; j <= closingIndex; j++)
                {
                    Console.Write(input[j]);
                }
                Console.WriteLine();
            }
        }
    }
}