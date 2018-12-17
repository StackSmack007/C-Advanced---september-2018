using System;
class Program
{
    static byte[] locationRC = { 7, 7 };//size of the chamber is 15/15(indexes between 0-14) so byte is sufficient!

    static void Main()
    {
        short playerHealth = 18_500;
        double HeiganHealth = 3_000_000f;
        short cloudDamage = 3500;//Damage per 1 turn;
        bool PlayerIsClouded = false; //Activated only if player is hit by cloud for extending duration of next turn!
        short eruptionDamage = 6000;
        double playerDamage = double.Parse(Console.ReadLine());
        string HeiganLastAtackType = "Plague Cloud";

        while (playerHealth >= 0 && HeiganHealth >= 0)
        {
            string[] input = Console.ReadLine().Split();
            string AtackType = input[0];
            sbyte[] atkCenterRowCol = { sbyte.Parse(input[1]), sbyte.Parse(input[2]) };
            HeiganHealth -= playerDamage;
            if (PlayerIsClouded)
            {
                PlayerIsClouded = false;//turnsOff PlagueDamaging
                playerHealth -= cloudDamage;
            }

            if (HeiganHealth <= 0 || playerHealth <= 0)
            {
                break;
            }

            if (!PlayerEscapes(atkCenterRowCol))
            {
                if (AtackType == "Cloud")
                {
                    playerHealth -= cloudDamage;
                    PlayerIsClouded = true;
                    if (HeiganLastAtackType != "Plague Cloud") HeiganLastAtackType = "Plague Cloud";//rewrites atkType if need be
                }

                else if (AtackType == "Eruption")
                {
                    playerHealth -= eruptionDamage;
                    if (HeiganLastAtackType != "Eruption") HeiganLastAtackType = "Eruption";//rewrites atkType if need be
                }
            }

            else
            {
                MovePlayer(atkCenterRowCol);
            }
        }

        Console.WriteLine("Heigan: {0}", HeiganHealth <= 0 ? "Defeated!" : $"{HeiganHealth:F2}");
        Console.WriteLine(playerHealth <= 0 ? $"Player: Killed by {HeiganLastAtackType}" : $"Player: {playerHealth}");
        Console.WriteLine("Final position: {0}", string.Join(", ", locationRC));
    }
    static bool PlayerEscapes(sbyte[] atkCenter)
    {
        if (atkCenter[0] == locationRC[0] && atkCenter[1] == locationRC[1])
        {
            return false;//inside cases(1-13,1-13)
        }
        else if ((locationRC[1] == 0 && atkCenter[1] == 1 && atkCenter[0] == locationRC[0]) ||
             (locationRC[1] == 14 && atkCenter[1] == 13 && atkCenter[0] == locationRC[0]) ||
             (locationRC[0] == 0 && atkCenter[0] == 1 && atkCenter[1] == locationRC[1]) ||
             (locationRC[0] == 14 && atkCenter[0] == 13 && atkCenter[1] == locationRC[1]))
        {
            return false;//borderCases includes all except some of the corner cases (0,1; 1,0; 14,0; 0,14)
        }
        else if ((locationRC[0] == 0 && locationRC[1] == 0 && atkCenter[0] == 1 && atkCenter[1] == 1) ||
        (locationRC[0] == 0 && locationRC[1] == 14 && atkCenter[0] == 1 && atkCenter[1] == 13) ||
        (locationRC[0] == 14 && locationRC[1] == 0 && atkCenter[0] == 13 && atkCenter[1] == 1) ||
        (locationRC[0] == 14 && locationRC[1] == 14 && atkCenter[0] == 13 && atkCenter[1] == 13))
        {
            return false;//corner cases which are included from border cases
        }
        return true;
    }

    static void MovePlayer(sbyte[] atkCenter)
    {
        if ((locationRC[0] <= atkCenter[0] + 1 && locationRC[0] >= atkCenter[0] - 1 && locationRC[1] <= atkCenter[1] + 1 & locationRC[1] >= atkCenter[1] - 1))
        {  //Ensures that Move player is located in the blast zone, thus relocation is meaningfull!
            if (IsInsideChamberAndOutsideAtkZone(locationRC[0] - 1, locationRC[1], atkCenter)) locationRC[0]--;
            else if (IsInsideChamberAndOutsideAtkZone(locationRC[0], locationRC[1] + 1, atkCenter)) locationRC[1]++;
            else if (IsInsideChamberAndOutsideAtkZone(locationRC[0] + 1, locationRC[1], atkCenter)) locationRC[0]++;
            else if (IsInsideChamberAndOutsideAtkZone(locationRC[0], locationRC[1] - 1, atkCenter)) locationRC[1]--;
        }
    }

    static bool IsInsideChamberAndOutsideAtkZone(int rowProposal, int colProposal, sbyte[] atkCenter)
    {
        if ((rowProposal >= 0 && rowProposal < 15 && colProposal >= 0 && colProposal < 15) &&
           ((rowProposal < atkCenter[0] - 1 || rowProposal > atkCenter[0] + 1) || (colProposal < atkCenter[1] - 1 || colProposal > atkCenter[1] + 1)))
        {
            return true;// proposal position is in the chamber and not in the atackZone
        }
        return false;
    }
}