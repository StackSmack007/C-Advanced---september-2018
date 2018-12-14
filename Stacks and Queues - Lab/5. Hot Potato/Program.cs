using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int turns = int.Parse(Console.ReadLine()) - 1;
        Queue<string> kidsNames = new Queue<string>(input);
        while (kidsNames.Count>1)
        {
            for (int i = 0; i < turns; i++)
            {
                kidsNames.Enqueue(kidsNames.Dequeue());
            }
            Console.WriteLine("Removed "+kidsNames.Dequeue());
        }
        Console.WriteLine("Last is "+ kidsNames.Dequeue());
    }
}