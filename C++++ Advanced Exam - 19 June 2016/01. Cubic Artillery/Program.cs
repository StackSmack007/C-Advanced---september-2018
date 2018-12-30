using System;
using System.Collections.Generic;
using System.Linq;
//10:30
class Program
{
    static void Main()
    {
        int bunkerCappacity = int.Parse(Console.ReadLine());
        Queue<int> currentBunker = new Queue<int>();
        Queue<char> bunkersLetters = new Queue<char>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "Bunker" && input[1] == "Revision")
            {
                break;
            }
            foreach (string entry in input)
            {
                int value = 0;
                bool isWeapon = int.TryParse(entry, out value);
                if (!isWeapon)
                {
                    bunkersLetters.Enqueue(char.Parse(entry));
                    continue;
                }
                if (currentBunker.Sum() + value <= bunkerCappacity)
                {
                    currentBunker.Enqueue(value);
                }
                else if (bunkersLetters.Count == 1)
                {
                    if (value <= bunkerCappacity)
                    {
                        while (currentBunker.Sum() + value > bunkerCappacity)
                        {
                            currentBunker.Dequeue();
                        }
                        currentBunker.Enqueue(value);
                        continue;
                    }
                }
                else//overflowing
                {
                    if (currentBunker.Count == 0)
                    {
                        Console.WriteLine($"{bunkersLetters.Dequeue()} -> {"Empty"}");
                    }
                    else
                    {
                        Console.WriteLine($"{bunkersLetters.Dequeue()} -> {string.Join(", ", currentBunker)}");
                        currentBunker.Clear();
                        if (value <= bunkerCappacity) currentBunker.Enqueue(value);
                    }
                }
            }
        }
    }
}//11:25//80/100 timeOptim