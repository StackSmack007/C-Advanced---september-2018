using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        var sequence = new Queue<double>();//ще я променям!
        sequence.Enqueue(double.Parse(Console.ReadLine()));

        int counter = 1;
        while (true)
        {
            double number = sequence.Dequeue();
            Console.Write(number + " ");
            sequence.Enqueue(number + 1);
            counter++; if (counter == 50) break;
            sequence.Enqueue(2 * number + 1);
            counter++; if (counter == 50) break;
            sequence.Enqueue(number + 2);
            counter++; if (counter == 50) break;
        }
        Console.WriteLine(string.Join(" ",sequence));
    }
}