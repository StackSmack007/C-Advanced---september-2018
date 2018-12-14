using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int countOfElementsIN = inputArr[0];
        int countOfElementsOUT = inputArr[1];
        countOfElementsOUT = countOfElementsOUT > countOfElementsIN ? countOfElementsIN : countOfElementsOUT;
        int numberToCheck = inputArr[2];
        int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); ;
        var result = new Stack<int>(elements);
        for (int i = 0; i < countOfElementsOUT; i++)
        {
            result.Pop();
        }
        if (result.Contains(numberToCheck))
        {
            Console.WriteLine("true");
        }
        else if (result.Count()==0)
        {
            Console.WriteLine(0);
        }
        else
        {
            int minNumber = int.MaxValue;
            while (result.Count>0)
            {
                int endNum = result.Pop();
                minNumber = endNum < minNumber ? endNum : minNumber;
            }
            Console.WriteLine(minNumber);
        }      
    }
}