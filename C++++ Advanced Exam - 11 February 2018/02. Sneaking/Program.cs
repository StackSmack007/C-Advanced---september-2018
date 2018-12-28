using System;
//11:10
class Program
{
    static void Main()
    {
        char[][] room = new char[int.Parse(Console.ReadLine())][];
        for (int i = 0; i < room.Length; i++)
        {
            char[] input = Console.ReadLine().ToCharArray();
            room[i] = input;
        }
        char[] directions = Console.ReadLine().ToCharArray();
        int[] Location = FindSam(room, 'S');
        foreach (char direction in directions)
        {
            EnemiesMove(room);
            if (IsSamKilled(room, Location))
            {
                break;
            }
            if (direction == 'W')
            {
                continue;
            }
            else
            {
                SamMoves(room, direction);
            }
            Location = FindSam(room, 'S');
            int indexOfNikoladze = Array.IndexOf(room[Location[0]], 'N');
            if (IsSamKilled(room, Location))
            {
                break;
            }
            else if (indexOfNikoladze != -1)
            {
                room[Location[0]][indexOfNikoladze] = 'X';
                Console.WriteLine("Nikoladze killed!");
                Print(room);
                return;
            }
        }
        Console.WriteLine("Sam died at {0}", string.Join(", ", Location));
        room[Location[0]][Location[1]] = 'X';
        Print(room);
    }
    static bool IsSamKilled(char[][] jag, int[] location)
    {
        char[] rowOfNote = jag[location[0]];
        int samCol = location[1];
        int b_col = Array.IndexOf(rowOfNote, 'b');
        int d_col = Array.IndexOf(rowOfNote, 'd');

        if ((b_col != -1 && b_col < samCol) || (d_col != -1 && d_col > samCol))
        {
            return true;
        }
        return false;
    }

    static int[] FindSam(char[][] jag, char symbol)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            if (Array.IndexOf(jag[i], symbol) != -1)
            {
                return new int[] { i, Array.IndexOf(jag[i], symbol) };
            }
        }
        return new int[] { -1, -1 };
    }

    static void SamMoves(char[][] jag, char direction)
    {
        int[] newLocation = FindSam(jag, 'S');
        jag[newLocation[0]][newLocation[1]] = '.';
        switch (direction)
        {
            case 'U': newLocation[0]--; break;
            case 'D': newLocation[0]++; break;
            case 'R': newLocation[1]++; break;
            case 'L': newLocation[1]--; break;
        }
        jag[newLocation[0]][newLocation[1]] = 'S';
    }

    static void EnemiesMove(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            MoveAtRowDB(jag[i], jag[i].Length);
        }
    }

    static void MoveAtRowDB(char[] row, int rowLength)
    {
        int b_index = Array.IndexOf(row, 'b');
        int d_index = Array.IndexOf(row, 'd');
        if (b_index != -1)//exists such
        {
            if (b_index + 1 == rowLength)
            {
                row[b_index] = 'd';
            }
            else
            {
                row[b_index] = '.';
                row[b_index + 1] = 'b';
            }
        }
        if (d_index != -1)//exists such
        {
            if (d_index == 0)
            {
                row[d_index] = 'b';
            }
            else
            {
                row[d_index] = '.';
                row[d_index - 1] = 'd';
            }
        }





    }

    static void Print(char[][] jag)
    {
        foreach (var arr in jag)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }
}
//12:30 - 90/100