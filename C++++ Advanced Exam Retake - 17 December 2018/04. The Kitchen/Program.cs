using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//11:50
class Program
{
    static void Main()
    {
        Stack<int> knifes = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        Queue<int> forks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        List<int> sets = new List<int>();
        while (knifes.Count>0&& forks.Count>0)
        {
            if (knifes.Peek()>forks.Peek())
            {
                sets.Add(knifes.Pop() + forks.Dequeue());
            }
            else if (forks.Peek() > knifes.Peek())
            {
                knifes.Pop();
            }
            else
            {
                forks.Dequeue();
                knifes.Push(knifes.Pop() + 1);
            }
        }
        Console.WriteLine("The biggest set is: {0}",sets.Max());
        Console.WriteLine(string.Join(" ",sets));
    }
}
//12:10