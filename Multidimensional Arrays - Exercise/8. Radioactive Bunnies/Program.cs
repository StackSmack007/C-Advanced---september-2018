using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[][] lair = new char[size[0]][];

        for (int i = 0; i < lair.Length; i++)
        {
            lair[i] = Console.ReadLine().ToCharArray();
        }

        string sequence = Console.ReadLine();

        foreach (char direction in sequence)
        {
            int[] location = GetPosition(lair);
            bool lairBreak = MoveAndEscape(lair, direction);
            bool isKilled = false;

            if (!lairBreak)
            {
                location = GetPosition(lair);
            }

            Populate(lair);
            if (!lairBreak & GetPosition(lair)[0] == -1)
            {
                isKilled = true;
            }
            if (lairBreak)
            {
                Print(lair);
                Console.WriteLine("won: {0}", string.Join(" ", location));
                break;
            }
            else if (isKilled)
            {
                Print(lair);
                Console.WriteLine("dead: {0}", string.Join(" ", location));
                break;
            }
        }
    }

    static int[] GetPosition(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == 'P')
                {
                    return new int[] { i, j };
                }
                else if (jag[i][j] == 'p')
                {
                    jag[i][j] = 'B';
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { -1, -1 };
    }

    static bool MoveAndEscape(char[][] jag, char direction)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == 'P')
                {
                    int[] newPosition = { i, j };
                    switch (direction)
                    {
                        case 'U':
                            newPosition[0] = i - 1;
                            break;
                        case 'D':
                            newPosition[0] = i + 1;
                            break;
                        case 'L':
                            newPosition[1] = j - 1;
                            break;
                        case 'R':
                            newPosition[1] = j + 1;
                            break;
                    }
                    if (newPosition[0] < 0 || newPosition[0] >= jag.Length || newPosition[1] < 0 || newPosition[1] >= jag[i].Length)
                    {
                        jag[i][j] = '.';
                        return true;
                    }
                    else if (jag[newPosition[0]][newPosition[1]] == 'B')
                    {
                        jag[i][j] = '.';
                        jag[newPosition[0]][newPosition[1]] = 'p';
                    }
                    else
                    {
                        jag[i][j] = '.';
                        jag[newPosition[0]][newPosition[1]] = 'P';
                    }
                    return false;
                }
            }
        }
        return false;
    }

    static void Print(char[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }

    static void Populate(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == 'B')
                {
                    if (i > 0)
                    {
                        if (jag[i - 1][j] != 'B')
                        {
                            jag[i - 1][j] = 's';
                        }
                    }
                    if (i < jag.Length - 1)
                    {
                        if (jag[i + 1][j] != 'B')
                        {
                            jag[i + 1][j] = 's';
                        }
                    }
                    if (j > 0)
                    {
                        if (jag[i][j - 1] != 'B')
                        {
                            jag[i][j - 1] = 's';
                        }
                    }
                    if (j < jag[i].Length - 1)
                    {
                        if (jag[i][j + 1] != 'B')
                        {
                            jag[i][j + 1] = 's';
                        }
                    }
                }
            }
        }
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == 's')
                {
                    jag[i][j] = 'B';
                }
            }
        }
    }
}