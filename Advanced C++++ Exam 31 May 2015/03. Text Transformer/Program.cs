using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{//16:15
    static void Main()
    {
        string pattern = @"(\$|%|&|')([^$'%&]+)\1";
        StringBuilder sb = new StringBuilder();
        string input;
        while ((input = Console.ReadLine()) != "burp")
        {
            sb.Append(input);
        }
        input = sb.ToString().Replace('\t', ' ');
        sb.Clear();
        MatchCollection wordsOfWisdom = Regex.Matches(input, pattern);
        foreach (Match match in wordsOfWisdom)
        {
            string symbol = match.Groups[1].Value;
            int weight = symbol == "$" ? 1 : symbol == "%" ? 2 : symbol == "&" ? 3 : 4;
            string word = match.Groups[2].Value;
            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append((char)(word[i] + weight));
                }
                else
                {
                    sb.Append((char)(word[i] - weight));
                }
            }
            sb.Append(' ');
        }
        Console.WriteLine(sb.ToString());
    }
}//16:40