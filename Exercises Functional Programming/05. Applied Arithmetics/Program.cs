using System;
using System.Linq;

class Program
{
    static Func<int[], int[]> Add1 = x => x.Select(n => n + 1).ToArray();
    static Func<int[], int[]> Subtract1 = x => x.Select(n => n - 1).ToArray();
    static Func<int[], int[]> Multiply2 = x => x.Select(n => n * 2).ToArray();
    static Action<int[]> PrintAll = x => Console.WriteLine(string.Join(" ", x));
    static void Main()
    {
        int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end") break;
            if (command == "add")
            {
                numArr = Add1(numArr);
            }
            else if (command == "subtract")
            {
                numArr = Subtract1(numArr);
            }
            else if (command == "multiply")
            {
                numArr = Multiply2(numArr);
            }
            else if (command == "print")
            {
                PrintAll(numArr);
            }
        }
    }
}