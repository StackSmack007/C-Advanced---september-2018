using System;
using System.Text;
using System.Text.RegularExpressions;
class Program
{//12:35
    static void Main()
    {
        int rowsN = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rowsN; i++)
        {
            sb.Append(Console.ReadLine());
        }
        string text = sb.ToString();
        sb.Clear();
        string pattern = @"((?<opener>\[)|{)[^\d]*(?<digits>(\d{3})+)[^\d]*(?(opener)\]|})";
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match code in matches)
        {
            int length = code.Value.Length;
            string digits = code.Groups["digits"].Value;
            for (int i = 0; i < digits.Length/3; i++)
            {
                char letter = (char)(int.Parse(digits.Substring(3 * i, 3))-length);
                sb.Append(letter);
            }
        }

        Console.WriteLine(sb.ToString());
    }
}
//13:15