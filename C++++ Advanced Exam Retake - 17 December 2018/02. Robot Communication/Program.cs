using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//10:50
class Program
{
    static void Main()
    {
        string pattern = @"(,|_)([a-zA-Z]+)(\d)";
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Report")
            {
                break;
            }
            MatchCollection matches = Regex.Matches(input, pattern);
            Queue<string> messages = new Queue<string>(matches.Count);
            foreach (Match match in matches)
            {
                string symbol = match.Groups[1].Value;      
                int value = int.Parse(match.Groups[3].Value);
                var message = string.Join("",(match.Groups[2].Value).ToCharArray().Select(x=>(char)(symbol==","?x+value:x-value)));
                messages.Enqueue(message);
            }
            Console.WriteLine(string.Join(" ",messages));
        }
    }
}
//11:15