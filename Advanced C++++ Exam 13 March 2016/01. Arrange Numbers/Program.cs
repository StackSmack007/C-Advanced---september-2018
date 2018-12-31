using System;
using System.Linq;

class Program
    {
        static void Main()
        {
        string[] arrayN = Console.ReadLine().Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries)
                                            .OrderBy(x=>GetWholeName(x))
                                            .ThenBy(x=> GetWholeName(x).Length)
                                            .ToArray();
        Console.WriteLine(string.Join(", ",arrayN));
        }

    static string GetWholeName(string number)
    {
        string[] digitNames = new string[number.Length];
        for (int i = 0; i < number.Length; i++)
        {
            digitNames[i] = GetDigitName(number[i]);
        }
        return string.Join("-",digitNames);
    }

    static string GetDigitName(char digit)
    {
        switch (digit)
        {
            case '1':
                return "one";
            case '2':
                return "two";
            case '3':
                return "three";
            case '4':
                return "four";
            case '5':
                return "five";
            case '6':
                return "six";
            case '7':
                return "seven";
            case '8':
                return "eight";
            case '9':
                return "nine";
            default:
                return "zero";
        }
    }
    }