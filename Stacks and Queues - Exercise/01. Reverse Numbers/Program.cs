using System;

using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] {' ','\t' },StringSplitOptions.RemoveEmptyEntries);
        Stack<string> result = new Stack<string>();
        
        foreach (var item in inputArr)
        {
            result.Push(item);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}