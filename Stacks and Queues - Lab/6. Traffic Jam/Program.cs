using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int passCount = int.Parse(Console.ReadLine());
        int carsCountTotalPassed = 0;
        Queue<string> carsModels = new Queue<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            if (input=="green")
            {
                int amauntOfCars = passCount <= carsModels.Count ? passCount : carsModels.Count;
                for (int i = 1; i <= amauntOfCars; i++)
                {
                    Console.WriteLine(carsModels.Dequeue()+" passed!");
                    carsCountTotalPassed++;
                }
            }
            else
            {
                carsModels.Enqueue(input);
            }
        }
        Console.WriteLine("{0} cars passed the crossroads.",carsCountTotalPassed);
    }
}