using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Dictionary<char, char> openCloseSymbol = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
        string inputLine = Console.ReadLine();
        Stack<char> result = new Stack<char>();
        foreach (char symbol in inputLine)
        {
            if (result.Count > 0)
            {
                if (openCloseSymbol.ContainsKey(result.Peek()))
                {
                    if (openCloseSymbol[result.Peek()] == symbol)
                    {
                        result.Pop();
                        continue;
                    }
                }
            }
            result.Push(symbol);
        }
        if (result.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}