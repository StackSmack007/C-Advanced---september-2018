using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


//12:00
class Program
{
    static void Main()
    {

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Over!")
            {
                break;
            }
            int n = int.Parse(Console.ReadLine());
            string patternForMessage = $@"^\d+(?<message>[A-Za-z]{{{n}}})[^A-Za-z]*$";
            string patternForDigits = @"[\d]";
            Match messageMatch = Regex.Match(input, patternForMessage);
            MatchCollection digits = Regex.Matches(input, patternForDigits);
            if (!messageMatch.Success)
            {
                continue;
            }
            List<char> decipheredSymbols = new List<char>(digits.Count);
            string message = messageMatch.Groups["message"].Value;
            foreach (Match digit in digits)
            {
                int index = int.Parse(digit.Value);
                if (index < message.Length)
                {
                    decipheredSymbols.Add(message[index]);
                }
                else
                {
                    decipheredSymbols.Add(' ');
                }
            }
            Console.WriteLine($"{message} == {string.Join("",decipheredSymbols)}");
        }
    }
}
//12:25