using System;
using System.Collections.Generic;
//11:00
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string pattern = @"\[[^\s\t<>\]\[]+<((?<fNum>\d+)(?:REGEH)(?<sNum>\d+))>[^\s\t<>\]\[]+\]";
        string text = Console.ReadLine();

        MatchCollection matches = Regex.Matches(text, pattern);
        int index = 0;
        string result = "";
        Queue<int> numbers = new Queue<int>(matches.Count*2);
        foreach (Match match in matches)
        {
            int firstNumber = int.Parse(match.Groups["fNum"].Value);
            numbers.Enqueue(firstNumber);
            int secondNumber = int.Parse(match.Groups["sNum"].Value);
            numbers.Enqueue(secondNumber);
        }
        while (numbers.Count>0)
        {
            index = index + numbers.Dequeue();
            if (index>=text.Length)
            {
                index %= text.Length-1;
            }
            Console.Write(text[index]);
        }
        Console.WriteLine();
    }
}
//11:45