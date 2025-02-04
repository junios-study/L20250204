using System;
using System.Security.Cryptography;

namespace L20250204
{
    internal class Program
    {
        static uint A = 1103515245;
        static uint C = 12345;
        static uint M = 2147483648;

        static uint seed = 1;

        static uint rand()
        {
            seed = (A * seed + C) % M;
            return seed;
        }

        static void Main(string[] args)
        {
            int[] deck = new int[52];

            //1 - 13 -> Heart , 1 -> A, 11 -> J, 12 -> Q , 13 -> K
            //14 - 26 -> Diamond
            //27 - 39 -> Clover
            //40 - 52 -> Spade 
            //Initialize
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }

            //Shuffle 
            Random random = new Random();

            for (int i = 0; i < deck.Length * 10; ++i)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }

            //Print
            for (int i = 0; i < 8; ++i)
            {
                Console.WriteLine(deck[i]);
            }
        }
    }
}
