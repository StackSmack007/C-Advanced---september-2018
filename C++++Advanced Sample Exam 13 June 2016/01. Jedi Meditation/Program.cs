using System;
using System.Collections.Generic;
using System.Linq;
//17:00
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> meditators = new List<string>();
        Queue<string> masters = new Queue<string>();
        Queue<string> knights = new Queue<string>();
        Queue<string> padwans = new Queue<string>();

        bool hasYoda = false;
        for (int i = 0; i < n; i++)
        {
            meditators.AddRange(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        if (meditators.Any(x => x[0] == 'y'))
        {
            hasYoda = true;
            meditators.RemoveAll(x => x[0] == 'y');
        }
        FillStack(meditators, hasYoda ? padwans : masters, new char[]{ 't','s'});
        FillMasterKnightPadwanQueues(meditators, masters, knights, padwans);
        Console.WriteLine(string.Join(" ",masters)+" "+string.Join(" ", knights) + " " + string.Join(" ", padwans));
    }

    static void FillStack(List<string> list, Queue<string> stack, char[] symbol)
    {
        foreach (var jedi in list.Where(x => symbol.Contains(x[0])))
        {
            stack.Enqueue(jedi);
        }
    }

    static void FillMasterKnightPadwanQueues(List<string> list, Queue<string> M, Queue<string> K, Queue<string> P)
    {
        foreach (var jedi in list)
        {
            if (jedi[0] == 'm') M.Enqueue(jedi);
            if (jedi[0] == 'k') K.Enqueue(jedi);
            if (jedi[0]=='p') P.Enqueue(jedi);
        }
    }
}
//17:56