using System;
using System.Collections.Generic;
using System.Linq;
//19:33

class Program
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] contentSafe = Console.ReadLine().Split(new char[] { ' ','\t',',','-'},StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, long>[] GoldGemCash = new Dictionary<string, long>[3]
        { new Dictionary<string, long>{["gold"]=0 }, new Dictionary<string, long>(), new Dictionary<string, long>()};
        long overallQuantity = 0;
        for (long i = 0; i < contentSafe.Length; i += 2)
        {
            string nameItem = contentSafe[i];
            long quantity = long.Parse(contentSafe[i + 1]);
            if (bagCapacity - overallQuantity< quantity)
            {
                continue;
            }
            if (nameItem.ToLower() == "gold")
            {
                GoldGemCash[0]["gold"] += quantity;
                overallQuantity += quantity;
            }
            else if (nameItem.ToLower().EndsWith("gem")&& nameItem.Length>=4 && GoldGemCash[1].Sum(x => x.Value) + quantity <= GoldGemCash[0]["gold"])
            {
                if (!GoldGemCash[1].ContainsKey(nameItem))
                {
                    GoldGemCash[1][nameItem] = quantity;
                }
                else
                {
                    GoldGemCash[1][nameItem] += quantity;
                }
            }
            else if (nameItem.Length == 3 && GoldGemCash[2].Sum(x => x.Value) + quantity <= GoldGemCash[1].Sum(x => x.Value))
            {
                if (!GoldGemCash[2].ContainsKey(nameItem))
                {
                    GoldGemCash[2][nameItem] = quantity;
                }
                else
                {
                    GoldGemCash[2][nameItem] += quantity;
                }
            }
        }
        if (GoldGemCash[0]["gold"] > 0)
        {
            Console.WriteLine("<Gold> ${0}", GoldGemCash[0]["gold"]);
            Console.WriteLine("##Gold - {0}", GoldGemCash[0]["gold"]);
        }
        if (GoldGemCash[1].Count() > 0)
        {
            Console.WriteLine("<Gem> ${0}", GoldGemCash[1].Sum(x => x.Value));
            foreach (var kvp in GoldGemCash[1].OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
            }
        }
        if (GoldGemCash[2].Count() > 0)
        {
            Console.WriteLine("<Cash> ${0}", GoldGemCash[2].Sum(x => x.Value));
            foreach (var kvp in GoldGemCash[2].OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
//20:44 - 80/100