using System;
using System.Linq;
using System.Numerics;
//17:30
class Program
{
    static void Main()
    {
        BigInteger[] numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
        int index = 0;
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        while (input[0] != "stop")
        {
            int offset = int.Parse(input[0]);
            long value = long.Parse(input[2]);
            string operation = input[1];
            index += offset;
            if (index >= numbers.Length)
            {
                index = 0 + index % (numbers.Length);
            }
            else if (index < 0)
            {
                int count = (int)Math.Ceiling(-index*1.0 / numbers.Length);
                index += count * numbers.Length;
            }
            Operate(numbers, index, value, operation);
            input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        Console.WriteLine($"[{string.Join(", ", numbers)}]");
    }

    static void Operate(BigInteger[] array, int index, long value, string operation)
    {
        switch (operation)
        {
            case "+": array[index] += value; break;
            case "-": array[index] = BigInteger.Max(0, array[index] - value); break;
            case "*": array[index] *= value; break;
            case "/":
                if (value == 0) { return; }
                array[index] /= value; break;
            case "^": array[index] ^= value; break;
            case "&": array[index] &= value; break;
            case "|": array[index] |= value; break;
        }
    }
}
//18:45