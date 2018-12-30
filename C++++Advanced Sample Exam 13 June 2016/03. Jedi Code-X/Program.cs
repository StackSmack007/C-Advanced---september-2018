using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//20:00
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Queue<string> inputRows = new Queue<string>(n);
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            inputRows.Enqueue(input);
        }
        string jed = Console.ReadLine();
        string mes = Console.ReadLine();
        string text = string.Join("", inputRows);
        MatchCollection jediesMatches = Regex.Matches(text, $@"{jed}([a-zA-Z]{{{jed.Length}}})(?![a-zA-Z])");
        MatchCollection messagesMatches = Regex.Matches(text, $@"{mes}([a-zA-Z0-9]{{{mes.Length}}})(?!\w)");

        Queue<string> jedyNames = new Queue<string>(jediesMatches.Count);
        foreach (Match jedy in jediesMatches)
        {
            jedyNames.Enqueue(jedy.Groups[1].Value);
        }
        List<string> messages = new List<string>(messagesMatches.Count);

        foreach (Match message in messagesMatches)
        {
            messages.Add(message.Groups[1].Value);
        }
        int[] indexesArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x) - 1).Where(x => x > -1 && x < messages.Count).ToArray();
        for (int i = 0; i < indexesArr.Length; i++)
        {
            if (jedyNames.Count == 0)
            {
                break;
            }
            Console.WriteLine($"{jedyNames.Dequeue()} - {messages[indexesArr[i]]}");
        }
    }
}
//21:45