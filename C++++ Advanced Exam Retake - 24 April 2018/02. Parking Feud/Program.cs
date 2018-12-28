using System;
using System.Collections.Generic;
using System.Linq;
class Program
{//14:05
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();//rows cols
        int entranceRow = int.Parse(Console.ReadLine());
        int movesPassed = 0;
        Stack<string> parkingSpot = new Stack<string>();

        while (true)
        {
            var parkingSpots = Console.ReadLine().Split(' ');
            parkingSpot.Push(parkingSpots[entranceRow - 1]);
            parkingSpots[entranceRow - 1] = "*";
            var indexOfCompetitor = Array.IndexOf(parkingSpots, parkingSpot.Peek())+1;
            int distancePassedToGetInPlace = DistanceGet(size[1],entranceRow,RowCol(parkingSpot.Peek()));

            movesPassed += distancePassedToGetInPlace;

            if (indexOfCompetitor>0)
            {
                if (distancePassedToGetInPlace> DistanceGet(size[1], indexOfCompetitor, RowCol(parkingSpot.Peek())))
                {
                    movesPassed += distancePassedToGetInPlace;
                    continue;
                }
            }

            break;
        }

        Console.WriteLine($"Parked successfully at {parkingSpot.Pop()}.");
        Console.WriteLine($"Total Distance Passed: {movesPassed}");
    }

    static int[] RowCol(string place)
    {
        int row = int.Parse(place.Substring(1));//As it is 1 is 1 there is no 0!
        int col = place[0] - 'A'+1;//As it is 1 is 1 there is no 0!
        return new int[] { row, col };
    }
  
    static int DistanceGet(int ColsCount,int entryRow,int[] RowCol)
    {//from all colls we subtract 1 because it is entry one
        int targetRow = RowCol[0];
        int targetCol = RowCol[1];
        int distance = 0;
        int countOfRowsToSkip = Math.Abs(targetRow - entryRow);
        if (targetRow>entryRow)
        {
            countOfRowsToSkip--;
        }
        
if (countOfRowsToSkip <= 0)
        {
            distance = targetCol;
        }
        else
        {
            distance = (countOfRowsToSkip) * (ColsCount + 3);
            if (countOfRowsToSkip%2==0)
            {
                distance += targetCol;
            }
            else
            {
                distance += ColsCount - targetCol+1;
            }
        }
       return distance;
    }
}//16:00