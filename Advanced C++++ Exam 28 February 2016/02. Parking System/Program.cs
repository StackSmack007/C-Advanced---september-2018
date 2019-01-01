using System;
using System.Linq;
//13:30
class Program
{
    static void Main()
    {
        int[] rowsColsN = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); rowsColsN[1]--;
        int[][] parkingSpots = new int[rowsColsN[0]][];

        string input = Console.ReadLine();
        while (input != "stop")
        {
            int[] parkingData = input.Split(' ').Select(int.Parse).ToArray();
            int spotRow = parkingData[1];

            if (parkingSpots[spotRow] is null)
            {
                parkingSpots[spotRow] = new int[rowsColsN[1]];
            }
            if (!parkingSpots[spotRow].Contains(0))
            {
                Console.WriteLine($"Row {spotRow} full");
            }
            else
            {
                Console.WriteLine(GetDistance(parkingSpots, parkingData));
            }

            input = Console.ReadLine();
        }
    }

    private static int GetDistance(int[][] parkingSpots, int[] parkingData)
    {
        int entryRow = parkingData[0];
        int spotRow = parkingData[1];
        int spotCol = parkingData[2] - 1;
        int distance = Math.Abs(entryRow - spotRow);
        int n = Math.Max(parkingSpots[spotRow].Length - spotCol, spotCol);
        for (int i = 0; i <= n; i++)
        {
            int leftTry = spotCol - i;
            int rightTry = spotCol + i;
            if (isInside(parkingSpots[spotRow], leftTry))
            {
                if (parkingSpots[spotRow][leftTry] == 0)
                {
                    parkingSpots[spotRow][leftTry] = 1;
                    distance += leftTry;
                    break;
                }
            }
            if (isInside(parkingSpots[spotRow], rightTry))
            {
                if (parkingSpots[spotRow][rightTry] == 0)
                {
                    parkingSpots[spotRow][rightTry] = 1;
                    distance += rightTry;
                    break;
                }
            }
        }
        return distance + 2;
    }

    static bool isInside(int[] arr, int index)
    {
        if (index > -1 && index < arr.Length)
        {
            return true;
        }
        return false;
    }
}//14:15