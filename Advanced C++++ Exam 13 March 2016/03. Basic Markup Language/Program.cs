using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int currentNumber = 0;
        string pattern = @"<\s*((?<operator>inverse|reverse)|repeat)(?(operator)|\s*value\s*=\s*""(?<quantity>\d+)"")\s*content\s*=\s*""(?<content>.+)""\s*\/>";
        string ending = "<stop/>";
        while (true)
        {
            string input = Console.ReadLine();
         //   input = input.Replace('\t', ' ');
            if (input.Contains(ending))
            {
                break;
            }
            Match matches = Regex.Match(input, pattern);
            if (matches.Success)
            {
                char[] message = matches.Groups["content"].Value.ToCharArray();
                if (matches.Groups["operator"].Value == "reverse")
                {
                    Array.Reverse(message);
                    Console.WriteLine($"{++currentNumber}. " + string.Join($"", message));
                }
                else if (matches.Groups["operator"].Value == "inverse")
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        if (char.IsLetter(message[i]))
                        {
                            if (char.IsUpper(message[i]))
                            {
                                message[i] = (char)(message[i] + ('a' - 'A'));
                            }
                            else
                            {
                                message[i] = (char)(message[i] - ('a' - 'A'));
                            }
                        }
                    }
                    Console.WriteLine($"{++currentNumber}. " + string.Join($"", message));
                }
                if (matches.Groups["quantity"].Success)
                {
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.WriteLine($"{++currentNumber}. " + string.Join($"", message));
                    }
                }
            }
        }
    }
}