using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        Dictionary<string, List<float>> studentsGrades = new Dictionary<string, List<float>>();
        for (int i = 0; i < n; i++)
        {
           string[] input=Console.ReadLine().Split(' ');
            string name = input[0];
            float grade = float.Parse(input[1]);
            if (!studentsGrades.ContainsKey(name))
            {
                studentsGrades[name] = new List<float> { grade };
            }
            else
            {
                studentsGrades[name].Add(grade);
            }
        }
        foreach (var kvp in studentsGrades)
        {
            Console.Write("{0} -> ", kvp.Key);
            float avg = 0;
            foreach (var item in kvp.Value)
            {
                avg += item;
                Console.Write("{0:F2} ",item);
            }
            avg /= kvp.Value.Count;
            Console.WriteLine("(avg: {0:F2})",avg);
        }
    }
}