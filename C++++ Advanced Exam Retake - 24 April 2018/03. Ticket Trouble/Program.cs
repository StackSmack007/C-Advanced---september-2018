using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{//16:00
    static void Main()
    {
        string location = Console.ReadLine();
        string pattern = @"({|\[)[^\{\}\]\[]*({|\[)" + location + @"(\}|\])[^\{\}\]\[]*({|\[)(\w+)(\}|\])[^\{\}\]\[]*(\}|\])";
        string text = Console.ReadLine();
        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> seats = new List<string>();
        foreach (Match ticket in matches)
        {
            var ade = char.Parse(ticket.Groups[1].Value);
            if (char.Parse(ticket.Groups[1].Value) + 2 == char.Parse(ticket.Groups[7].Value) &&
                char.Parse(ticket.Groups[2].Value) + 2 == char.Parse(ticket.Groups[3].Value) &&
                char.Parse(ticket.Groups[4].Value) + 2 == char.Parse(ticket.Groups[6].Value)&&
                char.Parse(ticket.Groups[2].Value) == char.Parse(ticket.Groups[4].Value)&&
                char.Parse(ticket.Groups[2].Value) != char.Parse(ticket.Groups[1].Value))
            {
                seats.Add(ticket.Groups[5].Value);
            }
        }
        seats = seats.Distinct().ToList();
        string seat1 = seats[0];
        string seat2 = seats[1];
        while (seats.Count > 2)
        {
            int indexOfSeat2 = seats.FindLastIndex(x => x.Substring(1) == seats[0].Substring(1));
            if (indexOfSeat2 != 0)
            {
                seat1 = seats[0];
                seat2 = seats[indexOfSeat2];
                break;
            }
            seats.RemoveAt(0);
            if (seats.Count==2)
            {
               seat1 = seats[0];
               seat2 = seats[1];
            }
        }
        Console.WriteLine($"You are traveling to {location} on seats {seat1} and {seat2}.");
    }
}//16:45