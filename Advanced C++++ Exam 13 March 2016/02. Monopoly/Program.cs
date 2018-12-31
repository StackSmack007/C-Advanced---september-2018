using System;
using System.Linq;

class Program
{
    static int[] location = { 0, -1 };
    static void Main()
    {
        int money = 50;
        int turn = 0;
        byte jailTime = 0;
        int hotelCounts = 0;
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[][] map = new char[size[0]][];
        FillMap(map);
        while (true)
        {
            if (jailTime == 0)
            {
                char TurnEvent = Move(map);
                if (TurnEvent == 'H')
                {
                    Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++hotelCounts}.");
                    money = 0;
                }
                if (TurnEvent == 'S')
                {
                    var purchaseCost = Math.Min(money, (location[0] + 1) * (location[1] + 1));
                    Console.WriteLine($"Spent {purchaseCost} money at the shop.");
                    money -= purchaseCost;
                }
                if (TurnEvent == 'J')
                {
                    Console.WriteLine($"Gone to jail at turn {turn}.");
                    jailTime = 2;
                }
            }
            else
            {
                jailTime--;
            }
            //processTurns
            turn++;
            money += hotelCounts * 10; //break conditioning For Last Index
            if (location[0] == map.Length - 1 && jailTime == 0)//We are at the Last Row
            {
                if ((map.Length % 2 != 0 && location[1] == map[location[0]].Length - 1) ||
                    (map.Length % 2 == 0 && location[1] == 0))
                {
                    break;
                }
            }
        }
        Console.WriteLine("Turns {0}", turn);
        Console.WriteLine("Money {0}", money);
    }
    static void FillMap(char[][] jag)
    {
        for (int i = 0; i < jag.Length; i++)
        {
            jag[i] = Console.ReadLine().ToCharArray();
        }
    }

    static char Move(char[][] jag)
    {
        if (location[0] % 2 == 0 && location[1] < jag[location[0]].Length - 1)
        { //Go Right
            location[1]++;
        }
        else if (location[0] % 2 == 1 && location[1] > 0)
        { //Go Left
            location[1]--;
        }
        else//Go Down
        {
            location[0]++;
        }
        return jag[location[0]][location[1]];
    }
}