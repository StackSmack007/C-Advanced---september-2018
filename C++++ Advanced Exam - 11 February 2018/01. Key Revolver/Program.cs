using System;
using System.Collections.Generic;
using System.Linq;
//10:30
class Program
{
    static void Main()
    {
        int priceForBullet = int.Parse(Console.ReadLine());
        int sizeOfBarrel = int.Parse(Console.ReadLine());
        Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        Queue<int> locks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        int prizeValue = int.Parse(Console.ReadLine()) - bullets.Count * priceForBullet;
        int bulletCounter = 0;
        while (bullets.Count > 0 && locks.Count > 0)
        {
            if (bullets.Peek() > locks.Peek())
            {
                Console.WriteLine("Ping!");
                bullets.Pop();

            }
            else
            {
                Console.WriteLine("Bang!");
                bullets.Pop();
                locks.Dequeue();
            }
            bulletCounter++;
            if (bulletCounter == sizeOfBarrel&&bullets.Count>0)
            {
                bulletCounter = 0;
                Console.WriteLine("Reloading!");
            }
        }

        prizeValue += bullets.Count * priceForBullet;
        if (locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else if (true)
        {
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${prizeValue}");
        }
    }
}//11:10