using System;
using System.Text.RegularExpressions;
using System.Linq;
//13:50
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string patternSenderReceiverMessage = @"s:([^;]+);r:([^;]+);m--(""[A-Za-z\s]*"")";
        string patternGetAllDigits = @"\d";
        string everythingButLetters = @"[^A-Za-z\s]";
        int sizeMbsCounter = 0;
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Match match = Regex.Match(input, patternSenderReceiverMessage);
            if (!(match.Success && match.Value == input))
            {
                continue;
            }
            Regex regex = new Regex(everythingButLetters);
            string sender = regex.Replace(match.Groups[1].Value, "");
            string receiver = regex.Replace(match.Groups[2].Value, "");
            string message = match.Groups[3].Value;
            MatchCollection digitsInMessage = Regex.Matches(input, patternGetAllDigits);
            foreach (Match digit in digitsInMessage)
            {
                sizeMbsCounter += int.Parse(digit.Value);
            }
            Console.WriteLine($"{sender} says {message} to {receiver}");
        }
        Console.WriteLine($"Total data transferred: {sizeMbsCounter}MB");
    }
}
//14:25