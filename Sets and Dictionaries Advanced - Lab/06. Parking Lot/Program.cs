using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> carNumbers = new HashSet<string>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(", ");
            if (input[0]== "END")
            {
                break;
            }
            string command = input[0];
            string carNumber = input[1];
            if (command=="IN")
            {
                carNumbers.Add(carNumber);
            }
            else
            {
                carNumbers.Remove(carNumber);
            }
                    }
        if (carNumbers.Count==0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        foreach (var cN in carNumbers)
        {
            Console.WriteLine(cN);
        }
    }
}