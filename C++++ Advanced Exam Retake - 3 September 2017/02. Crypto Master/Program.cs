using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        short[] baseSequence = Console.ReadLine().Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse).ToArray();
        int maxLength = 0;
        for (int span = 1; span < baseSequence.Length - 1; span++)
        {
            for (int i = 0; i < baseSequence.Length; i++)
            {
                int currentIndex = i;
                int newIndex = (currentIndex + span) % baseSequence.Length;
                int counter = 1;
                while (baseSequence[currentIndex] < baseSequence[newIndex])
                {
                    counter++;
                    currentIndex = newIndex;
                    newIndex= (currentIndex + span) % baseSequence.Length;
                }
                if (counter>maxLength)
                {
                    maxLength = counter;
                }
            }
        }
        Console.WriteLine(maxLength);
    }
}//90/100