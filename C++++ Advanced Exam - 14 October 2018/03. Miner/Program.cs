using System;
using System.Linq;

class Program
{
    static int coalsInitial = 0;
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] matrix = new char[size, size];
        string[] directions = Console.ReadLine().Split(' ');
        FillMatrix(matrix);
        int collectedCoals = 0;
        int[] location = FindIt(matrix, 's');

        foreach (string direction in directions)
        {
            int[] newLocationProposal = NewPosition(matrix, location, direction);
            if (matrix[newLocationProposal[0], newLocationProposal[1]] == 's')
            {
                continue;
            }
            else if (matrix[newLocationProposal[0], newLocationProposal[1]] == 'e')
            {
                Console.WriteLine($"Game over! ({string.Join(", ", newLocationProposal)})");
                return;
            }
            else if (matrix[newLocationProposal[0], newLocationProposal[1]] == 'c')
            {
                collectedCoals++;
                matrix[location[0], location[1]] = '*';
                matrix[newLocationProposal[0], newLocationProposal[1]] = 's';
            }
            else
            {
                matrix[location[0], location[1]] = '*';
                matrix[newLocationProposal[0], newLocationProposal[1]] = 's';
            }
            location = newLocationProposal;
            if (coalsInitial == collectedCoals)
            {
                Console.WriteLine($"You collected all coals! ({string.Join(", ", location)})");
                return;
            }
        }
        Console.WriteLine($"{coalsInitial - collectedCoals} coals left. ({string.Join(", ", location)})");
    }
    static void FillMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            char[] row = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (row[j] == 'c')
                {
                    coalsInitial++;
                }
                matrix[i, j] = row[j];
            }
        }
    }

    static int[] NewPosition(char[,] matrix, int[] location, string direction)
    {
        switch (direction)
        {
            case "up":
                if (IsValidPosition(matrix, location[0] - 1, location[1]))
                {
                    return new int[] { location[0] - 1, location[1] };
                }
                break;
            case "right":
                if (IsValidPosition(matrix, location[0], location[1] + 1))
                {
                    return new int[] { location[0], location[1] + 1 };
                }
                break;
            case "down":
                if (IsValidPosition(matrix, location[0] + 1, location[1]))
                {
                    return new int[] { location[0] + 1, location[1] };
                }
                break;
            case "left":
                if (IsValidPosition(matrix, location[0], location[1] - 1))
                {
                    return new int[] { location[0], location[1] - 1 };
                }
                break;
        }
        return location;
    }

    static bool IsValidPosition(char[,] matrix, int row, int col)
    {
        if (row > -1 && row < matrix.GetLength(0) && col > -1 && col < matrix.GetLength(1))
        {
            return true;
        }
        return false;
    }

    static int[] FindIt(char[,] matrix, char symbol)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == symbol)
                {
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { -1, -1 };
    }
}
//15:37