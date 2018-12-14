using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<long> fibbonacciRow = new Stack<long>();
        fibbonacciRow.Push(0);
        if (n == 0)
        {
            Console.WriteLine(fibbonacciRow.Pop());
            return;
        }
        fibbonacciRow.Push(1);
        if (n == 1)
        {
            Console.WriteLine(fibbonacciRow.Pop());
            return;
        }
        for (int i = 1; i < n; i++)
        {
            long lastOne = fibbonacciRow.Pop();
            long previousOne = fibbonacciRow.Peek();
            fibbonacciRow.Push(lastOne);
            fibbonacciRow.Push(lastOne + previousOne);
        }
        Console.WriteLine(fibbonacciRow.Pop());
    }
}