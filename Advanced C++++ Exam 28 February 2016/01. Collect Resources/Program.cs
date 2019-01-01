using System;
using System.Collections.Generic;
using System.Linq;
//:12:30
class Program
{
    static void Main()
    {
        string[] resoursesArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int collectionPaths = int.Parse(Console.ReadLine());
        int[][] paths = new int[collectionPaths][];
        CreatePaths(paths);
        long maxProffit = GetValueOfArray(resoursesArr, paths.OrderBy(x => -GetValueOfArray(resoursesArr, x)).First());
        Console.WriteLine(maxProffit);
    }

    static void CreatePaths(int[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            jag[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }

    static long GetValueOfArray(string[] res, int[] basePointAndStep)
    {
        long amauntGathered = 0;
        string[] goodsOfNote = { "stone", "gold", "wood", "food" };
        int index = basePointAndStep[0];
        int step = basePointAndStep[1];
        HashSet<int> indexesSteppedOn = new HashSet<int>();
        while (!indexesSteppedOn.Contains(index))
        {
            indexesSteppedOn.Add(index);
            string[] currentGood = res[index].Split(new char[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
            string good = currentGood[0];
            int quantity = currentGood.Length == 1 ? 1 : int.Parse(currentGood[1]);
            if (goodsOfNote.Contains(good))
            {
                amauntGathered += quantity;
            }
            index = (index + step) % res.Length;
        }
        return amauntGathered;
    }
}
//13:30