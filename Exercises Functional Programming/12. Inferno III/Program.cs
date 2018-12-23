using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] gems = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Dictionary<string, List<List<int>>> excludes = new Dictionary<string, List<List<int>>>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(';');
            if (input[0] == "Forge")
            {
                break;
            }
            string command = input[0];
            string filterType = input[1];
            int value = int.Parse(input[2]);

            if (command == "Reverse")
            {
                excludes[filterType].RemoveAt(excludes[filterType].Count - 1);
            }

            if (command == "Exclude")
            {
                if (!excludes.ContainsKey(filterType))
                {
                    excludes[filterType] = new List<List<int>>();
                }

                List<int> temp = new List<int>();
                for (int i = 0; i < gems.Length; i++)
                {
                    if (Check(gems, filterType, value, i))
                    {
                        temp.Add(i);
                    }
                }

                excludes[filterType].Add(temp);
            }
        }

        HashSet<int> allExcluded = new HashSet<int>();

        foreach (var kvp in excludes)
        {
            foreach (var excludeList in kvp.Value)
            {
                foreach (int index in excludeList)
                {
                    allExcluded.Add(index);
                }
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < gems.Length; i++)
        {
            if (allExcluded.Contains(i))
            {
                continue;
            }
            result.Add(gems[i]);
        }

        Console.WriteLine(string.Join(" ", result));
    }

        static bool Check(int[] gems, string filterType, int value, int index)
        {
            int gemValue = gems[index];
            if (filterType == "Sum Left")
            {
                gemValue += GetValidValue(gems, index - 1);
            }
            else if (filterType == "Sum Right")
            {
                gemValue += GetValidValue(gems, index + 1);
            }
            else
            {
                gemValue += GetValidValue(gems, index - 1) + GetValidValue(gems, index + 1);
            }
            if (gemValue == value)
            {
                return true;
            }
            return false;
        }

        static int GetValidValue(int[] numbersArr, int index)
        {
            if (index < 0 || index >= numbersArr.Length)
            {
                return 0;
            }
            return numbersArr[index];
        }
    }