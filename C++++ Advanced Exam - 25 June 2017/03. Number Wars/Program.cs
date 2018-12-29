using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<string> deck1 = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        Queue<string> deck2 = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

        for (int turn = 1; turn <= 10000; turn++)
        {
            if (deck1.Count == 0 || deck2.Count == 0)
            {
                PrintWinner(deck1, deck2, turn - 1);
                return;
            }
            string card1 = deck1.Dequeue();
            string card2 = deck2.Dequeue();

            if (GetValueOfNumber(card1) < GetValueOfNumber(card2))
            {
                deck2.Enqueue(card2);
                deck2.Enqueue(card1);
                continue;
            }
            else if (GetValueOfNumber(card1) > GetValueOfNumber(card2))
            {
                deck1.Enqueue(card1);
                deck1.Enqueue(card2);
                continue;
            }

            List<string> hand = new List<string> { card1, card2 };
            bool handWon = false;//cheks wheter the cards are taken or not by any player
            while (deck1.Count > 2 && deck2.Count > 2)
            {
                int winner = 0; //|>0 firstPlayer wins| <0 SecondPlayerWins| ==0 nobody wins|

                for (int i = 0; i < 3; i++)
                {
                    winner += deck1.Peek().Last() - deck2.Peek().Last();
                    hand.Add(deck1.Dequeue());
                    hand.Add(deck2.Dequeue());
                }

                if (winner > 0)
                {
                    handWon = TransferCards(deck1, hand);
                    break;
                }
                else if (winner < 0)
                {
                    handWon = TransferCards(deck2, hand);
                    break;
                }
            }

            if (!handWon)
            {
                PrintWinner(deck1, deck2, turn);
                return;
            }
        }

        PrintWinner(deck1, deck2, 1000000);
    }

    static int GetValueOfNumber(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    static bool TransferCards(Queue<string> deck, List<string> hand)
    {
        foreach (string card in hand.OrderByDescending(x => GetValueOfNumber(x)).ThenByDescending(x => x.Last()))
        {
            deck.Enqueue(card);
        }
        return true;
    }

    static void PrintWinner(Queue<string> deck1, Queue<string> deck2, int turns)
    {
        if (deck1.Count != deck2.Count)
        {
            Console.WriteLine("{0} player wins after {1} turns", deck1.Count > deck2.Count ? "First" : "Second", turns);
        }
        else
        {
            Console.WriteLine("Draw after {0} turns", turns);
        }
    }
}