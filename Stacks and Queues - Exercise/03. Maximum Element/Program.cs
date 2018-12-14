using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int quieriesN = int.Parse(Console.ReadLine());
        Stack<int> stackOfNumbers = new Stack<int>();
        Stack<int> stackOfMaxNs = new Stack<int>();
        for (int i = 0; i < quieriesN; i++)
        {
            int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (inputArr[0] == 1)
            {
                stackOfNumbers.Push(inputArr[1]);

                if (stackOfMaxNs.Count == 0)
                {
                    stackOfMaxNs.Push(inputArr[1]);
                }
                else if (stackOfMaxNs.Peek() <= inputArr[1])
                {
                    stackOfMaxNs.Push(inputArr[1]);
                }
            }
            if (inputArr[0] == 2)
            {
                if (stackOfMaxNs.Peek() == stackOfNumbers.Peek())
                {
                    stackOfMaxNs.Pop();
                }
                stackOfNumbers.Pop();
            }
            if (inputArr[0] == 3)
            {
                Console.WriteLine(stackOfMaxNs.Peek());
            }
        }
    }
}