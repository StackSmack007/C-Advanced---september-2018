using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        byte[][] parkingLot = new byte[size[0]][];//0- Empty! ; 1-Taken!
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "stop")
            {
                break;
            }
            int entryRowNumber = int.Parse(input[0]);
            int spotRow = int.Parse(input[1]);
            if (parkingLot[spotRow] is null)
            {
                parkingLot[spotRow] = new byte[size[1] - 1];
            }
            int spotCol = int.Parse(input[2]) - 1;//because of the reduced size of matrix

            int targetCol = FindAvailableSpotIndex(parkingLot, spotRow, spotCol);
            if (targetCol==-1)
            {
                Console.WriteLine($"Row {spotRow} full");
                continue;
            }
            int moves = Math.Abs(spotRow - entryRowNumber)+ targetCol + 2;//2 is because of the entry 1 plus zeroPassing is also 1 move
            Console.WriteLine(moves);
        }
    }
    static int FindAvailableSpotIndex(byte[][] jag, int row, int baseCol)
    {
        if (jag[row][baseCol] == 0)
        {
            jag[row][baseCol] = 1;
            return baseCol;
        }
        for (int i = 1; i <= Math.Max(baseCol, jag[row].Length - baseCol - 1); i++)
        {
            int leftTry = baseCol - i;
            int rightTry = baseCol + i;
            if (leftTry >= 0)
            {
                if (jag[row][leftTry] == 0)
                {
                    jag[row][leftTry] = 1;
                    return leftTry;
                }
            }
            if (rightTry < jag[row].Length)
            {
                if (jag[row][rightTry] == 0)
                {
                    jag[row][rightTry] = 1;
                    return rightTry;
                }
            }
        }
        return -1;
    }
}