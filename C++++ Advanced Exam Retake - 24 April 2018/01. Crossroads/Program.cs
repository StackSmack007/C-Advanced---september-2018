using System;
using System.Collections.Generic;
//11:10
class Program
{
    static void Main()
    {
        int greenLight = int.Parse(Console.ReadLine());
        int freeWindow = int.Parse(Console.ReadLine());

        Queue<string> carsWaiting = new Queue<string>();
        int totallCarsPassed = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input=="END")
            {
                break;
            }
            else if (input=="green")
            {
                int greenLightTemp = greenLight;

                while (carsWaiting.Count>0)
                {
                    string currentCar = carsWaiting.Dequeue();
                    if (currentCar.Length<greenLightTemp)
                    {
                        greenLightTemp -= currentCar.Length;
                        totallCarsPassed++;
                    }

                    else if (currentCar.Length<=(greenLightTemp+freeWindow))
                    {
                        totallCarsPassed++;
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"A crash happened!\n{currentCar} was hit at {currentCar[greenLightTemp + freeWindow]}.");
                        return;
                    }
                }
            }

            else
            {
                carsWaiting.Enqueue(input);
            }
        }

        Console.WriteLine($"Everyone is safe.\n{totallCarsPassed} total cars passed the crossroads.");
    }
}
//11:50