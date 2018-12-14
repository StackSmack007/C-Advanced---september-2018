using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int plantsTotal = int.Parse(Console.ReadLine());
        Stack<int> allPlants = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
        Stack<int> alivePlants = new Stack<int>();
        int day = 0;
        while (true)
        {
            int morningCount = allPlants.Count();
            for (int i = 0; i < morningCount-1; i++)
            {
                int takenPlant = allPlants.Pop();
                if (allPlants.Peek()>=takenPlant)
                {
                    alivePlants.Push(takenPlant);
                }
            }
            alivePlants.Push(allPlants.Pop());
            int eveningCount = alivePlants.Count();
            if (morningCount==eveningCount)
            {
                Console.WriteLine(day);
                return;
            }
            for (int i = 0; i < eveningCount; i++)
            {
                allPlants.Push(alivePlants.Pop());
            }
            day++;
        }
    }
}