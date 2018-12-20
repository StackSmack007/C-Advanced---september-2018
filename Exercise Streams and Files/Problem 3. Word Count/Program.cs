using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string pattern = @"[A-Za-z]+";
        Dictionary<string, int> wordRepeatance = new Dictionary<string, int>();
        using (StreamReader text = new StreamReader(Path.Combine("../../../../Resourses", "text.txt")))
        {
            MatchCollection wordsMatches = Regex.Matches(text.ReadToEnd(), pattern);
            string[] wordsInText = wordsMatches.Select(x=>x.ToString().ToLower()).ToArray();
            using (StreamReader wordsList = new StreamReader(Path.Combine("../../../../Resourses", "words.txt")))
            {
                while (true)
                {
                    string word = wordsList.ReadLine();
                    if (word == null)
                    {
                        break;
                    }
                    int wordCount = wordsInText.Count(x => x == word.ToLower());
                    wordRepeatance[word] = wordCount;
                }
            }
        }
        using (StreamWriter recorder=new StreamWriter(Path.Combine("../../../../Resourses/Results/Problem3Result.txt")))
        {
            foreach (var kvp in wordRepeatance.OrderByDescending(x=>x.Value))
            {
                recorder.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}