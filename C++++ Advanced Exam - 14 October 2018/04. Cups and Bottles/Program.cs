using System;
using System.Collections.Generic;
using System.Linq;
//15:37
class Program
{
    static void Main()
    {
        Queue<int> cups = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        int wastage = 0;
        while (cups.Count > 0 && bottles.Count > 0)
        {
            int currentCup = cups.Peek();
            while (currentCup >= 0)
            {
                if (currentCup <= bottles.Peek())
                {
                    wastage += bottles.Pop() - currentCup;
                    cups.Dequeue();
                    break;
                }
                else
                {
                    currentCup -= bottles.Pop();
                }
            }
        }
        if (bottles.Count == 0)
        {
            Console.WriteLine("Cups: {0}", string.Join(" ", cups));

        }
        else
        {
            Console.WriteLine("Bottles: {0}", string.Join(" ",bottles));
        }
       Console.WriteLine("Wasted litters of water: {0}", wastage);
    }
}
//16:00