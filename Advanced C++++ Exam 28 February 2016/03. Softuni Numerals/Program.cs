using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;

class Program
{//14:15
    static void Main()
    {
        MatchCollection matches = Regex.Matches(Console.ReadLine(), "aba|bcc|cdc|aa|cc");
        string number = GetNumber(matches);
        Console.WriteLine(Convert5baseTo10base(number));
    }
    static string GetNumber(MatchCollection matches)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Match match in matches)
        {
            switch (match.Value)
            {
                case "aa":
                    sb.Append(0);
                    break;
                case "aba":
                    sb.Append(1);
                    break;
                case "bcc":
                    sb.Append(2);
                    break;
                case "cc":
                    sb.Append(3);
                    break;
                case "cdc":
                    sb.Append(4);
                    break;
            }
        }
        return sb.ToString();
    }

    static BigInteger Convert5baseTo10base(string number)
    {
        BigInteger result = 0;
        for (byte i = 0; i < number.Length; i++)
        {
            uint digit = (uint)(number[i] - '0');
            var positionValue = BigInteger.Pow(5, number.Length - 1 - i);
            result += digit * positionValue;
        }
        return result;
    }
}//15:15
