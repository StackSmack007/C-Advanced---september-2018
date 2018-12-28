using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<streetN>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)";
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string inputLine = Console.ReadLine();
            MatchCollection matches = Regex.Matches(inputLine, pattern);
            string street = matches[matches.Count / 2 ].Groups["street"].Value;
            string strNumber = matches[matches.Count / 2 ].Groups["streetN"].Value;
            string password = matches[matches.Count / 2 ].Groups["password"].Value;
            Console.WriteLine($"Go to str. {street} {strNumber}. Secret pass: {password}.");
        }
    }
}