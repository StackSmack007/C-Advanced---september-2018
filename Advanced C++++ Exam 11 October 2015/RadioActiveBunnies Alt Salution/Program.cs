using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[] location = { -1, -1 }; //Affected by LocatePlayer 1time and movePlayer every turn
    static bool isKilled = false; //Affected by MovePlayer And BunnyPop
    static bool hasEscaped = false; //Affected by MovePlayer!
    static void Main()
    {
        int rows = Console.ReadLine().Split(' ').Select(int.Parse).ToArray()[0];
        char[][] cave = SetCave(rows);
        char[] directions = Console.ReadLine().ToUpper().ToCharArray();
        location = LocatePlayer(cave);

        foreach (char direction in directions)
        {
            MovePlayer(cave, direction);
            BunnyPop(cave);
            CheckResult(cave);
        }
    }

    static char[][] SetCave(int rows)
    {
        char[][] result = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            result[i] = Console.ReadLine().ToCharArray();
        }
        return result;
    }

    static bool IsInside(char[][] jag, int row, int col)
    {
        int jagRows = jag.Length;
        int jagCols = jag[0].Length;
        if (row >= 0 && row < jagRows && col >= 0 && col < jagCols)
        {
            return true;
        }
        return false;
    }

    static int[] LocatePlayer(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            for (int j = 0; j < jag[i].Length; j++)
            {
                if (jag[i][j] == 'P')
                {
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { -1, -1 };//means player is not found anywhere!
    }

    static void MovePlayer(char[][] cave, char direction)
    {
        cave[location[0]][location[1]] = '.';
        int newRow = location[0];
        int newCol = location[1];
        if (direction == 'U') newRow--;
        if (direction == 'D') newRow++;
        if (direction == 'L') newCol--;
        if (direction == 'R') newCol++;

        if (IsInside(cave, newRow, newCol))
        {
            location = new int[2] { newRow, newCol };
            if (cave[newRow][newCol] == '.')
            {
                cave[location[0]][location[1]] = 'P';
            }
            else
            {
                isKilled = true;
            }
        }
        else
        {
            hasEscaped = true;
        }
    }

    private static void BunnyPop(char[][] cave)
    {
        HashSet<int[]> bunnies = new HashSet<int[]>();
        for (int i = 0; i < cave.Length; i++)
        {
            for (int j = 0; j < cave[i].Length; j++)
            {
                if (cave[i][j] == 'B')
                {
                    bunnies.Add(new int[2] { i, j });
                }
            }
        }
        foreach (int[] roco in bunnies)
        {
            if (IsInside(cave, roco[0] - 1, roco[1])) cave[roco[0] - 1][roco[1]] = 'B';
            if (IsInside(cave, roco[0] + 1, roco[1])) cave[roco[0] + 1][roco[1]] = 'B';
            if (IsInside(cave, roco[0], roco[1] - 1)) cave[roco[0]][roco[1] - 1] = 'B';
            if (IsInside(cave, roco[0], roco[1] + 1)) cave[roco[0]][roco[1] + 1] = 'B';
        }
        if (LocatePlayer(cave)[0] == -1 && !hasEscaped)
        {
            isKilled = true;
        }
    }

    static void CheckResult(char[][] cave)
    {
        if (isKilled || hasEscaped)
        {
            PrintJagState(cave);
            Console.WriteLine("{0}: {1}", (isKilled ? "dead" : "won"), string.Join(" ", location));
            Environment.Exit(0);
        }
    }

    static void PrintJagState(char[][] jag)
    {
        foreach (char[] arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }
}