using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static Predicate<int> numCondition;
    static void Main()
    {
        int[] borders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        string condition = Console.ReadLine();

        numCondition = GetFunc(condition);
        Console.WriteLine(string.Join(" ",GetNumbers(borders,numCondition)));

    }
    static Queue<int> GetNumbers(int[] borders, Predicate<int> Z)
    {
        Queue<int> result = new Queue<int>();
        for (int i = borders[0]; i <=borders[1]; i++)
        {
            if (Z(i))
            {
                result.Enqueue(i);
            }
        }
        return result;
    }

    static Predicate<int> GetFunc(string condition)
    {
        if (condition == "odd")
        {
            return x => x % 2 != 0;
        }
        return x => x % 2 == 0;
    }
}