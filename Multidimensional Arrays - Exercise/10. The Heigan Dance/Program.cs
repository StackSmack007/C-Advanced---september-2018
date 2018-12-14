using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int playerHealth = 18500;
        double playerDamagePerTurn = double.Parse(Console.ReadLine());
        double HeiganHealth = 3000000;
        int[,] map = new int[15, 15];
        int[] location = { 7, 7 };
        Stack<int[]> clouds = new Stack<int[]>();//Cloud's center coordinates.
        bool deathCloudCouseOfDeath = false;

        while (playerHealth > 0 && HeiganHealth > 0)
        {
            string[] input = Console.ReadLine().Split(' ');
            string attackType = input[0];
            int damage = attackType == "Eruption" ? 6000 : 3500;
            int rowN = int.Parse(input[1]);
            int colN = int.Parse(input[2]);
            MarkDamageCells(map, rowN, colN);

            if (clouds.Count == 1)
            {
                int rowP = clouds.Peek()[0];
                int colP = clouds.Pop()[1];

                if (location[0] >= rowP - 1 && location[0] <= rowP + 1 && location[1] >= colP - 1 && location[1] <= colP + 1)
                {
                    playerHealth -= 3500; deathCloudCouseOfDeath = true;
                }
            }
            HeiganHealth -= playerDamagePerTurn;
            if (HeiganHealth <= 0)
            {
                continue;
            }
            if (playerHealth <= 0)
            {
                 continue;
            }

            if (location[0] >= rowN - 1 && location[0] <= rowN + 1 && location[1] >= colN - 1 && location[1] <= colN + 1)
            {
                bool escape = TryEscapingDamage(map, location);

                if (!escape)
                {
                    playerHealth -= damage;
                    deathCloudCouseOfDeath = damage==6000?false:true;
                }
            }
            if (attackType == "Cloud")
            {
                clouds.Push(new int[] { rowN, colN });
            }
            ClearAll(map);
        }
        if (HeiganHealth <= 0)
        {
            Console.WriteLine("Heigan: Defeated!");
        }
        else
        {
            Console.WriteLine($"Heigan: {HeiganHealth:F2}");
        }
        if (playerHealth <= 0)
        {
            Console.WriteLine("Player: Killed by " + (deathCloudCouseOfDeath ? "Plague Cloud" : "Eruption"));
        }
        else
        {
            Console.WriteLine($"Player: {playerHealth}");
        }
        Console.WriteLine("Final position: " + string.Join(", ", location));
    }
    static bool TryEscapingDamage(int[,] map, int[] location)
    {
        if (location[0] > 0)
        {
            if (map[location[0] - 1, location[1]] == 0)
            {
                location[0]--;
                return true;
            }
        }
        if (location[1] < map.GetLength(1) - 1)
        {
            if (map[location[0], location[1] + 1] == 0)
            {
                location[1]++;
                return true;
            }
        }
        if (location[0] < map.GetLength(0) - 1)
        {
            if (map[location[0] + 1, location[1]] == 0)
            {
                location[0]++;
                return true;
            }
        }
        if (location[1] > 0)
        {
            if (map[location[0], location[1] - 1] == 0)
            {
                location[1]--;
                return true;
            }
        }
        return false;
    }

    static void MarkDamageCells(int[,] map, int row, int col)
    {
        for (int i = Math.Max(row - 1, 0); i <= Math.Min(map.GetLength(0) - 1, row + 1); i++)
        {
            for (int j = Math.Max(col - 1, 0); j <= Math.Min(map.GetLength(1) - 1, col + 1); j++)
            {
                map[i, j] = -1;
            }
        }
    }

    static void ClearAll(int[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = 0;
            }
        }
    }
}