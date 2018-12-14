using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int pumpsN = int.Parse(Console.ReadLine());
        Queue<int[]> indexFuelDistance = new Queue<int[]>();
        for (int i = 0; i < pumpsN; i++)
        {
            indexFuelDistance.Enqueue($"{i} {Console.ReadLine()}".Split(' ').Select(int.Parse).ToArray());
        }
        for (int i = 0; i < pumpsN; i++)
        {
            bool succesfullJourney = true;
            int fuel = 0;
            for (int j = 0; j < pumpsN; j++)
            {
                fuel += indexFuelDistance.Peek()[1] - indexFuelDistance.Peek()[2];
                if (fuel<0)
                {
                    succesfullJourney = false;
                }
                indexFuelDistance.Enqueue(indexFuelDistance.Dequeue());
            }
            if (succesfullJourney) break;
            indexFuelDistance.Enqueue(indexFuelDistance.Dequeue());
        }
        Console.WriteLine(indexFuelDistance.Peek()[0]);
    }
}