using System;
using System.Data;
using System.Security.Cryptography;

namespace L20250204
{
    internal class Program
    {
        static void Initialize(int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
        }

        static void Shuffle(int[] deck)
        {
            Random random = new Random();

            for (int i = 0; i < deck.Length * 10; ++i)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }
        }

        enum CardType
        {
            None = -1,
            Heart = 0,
            Diamond = 1,
            Clover = 2,
            Spade = 3,
        }

        static void Print(int[] deck)
        {
            for (int i = 0; i < 8; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
            }
        }

        static CardType CheckCardType(int cardNumber)
        {
            int valueType = (cardNumber - 1) / 13;

            //CardType returnCardType = (CardType)valueType;
            //switch((CardType)valueType)
            //{
            //    case CardType.Heart:
            //        returnCardType = CardType.Heart;
            //        break;
            //    case CardType.Diamond:
            //        returnCardType = CardType.Diamond;
            //        break;
            //    case CardType.Spade:
            //        returnCardType = CardType.Spade;
            //        break;
            //    case CardType.Clover:
            //        returnCardType = CardType.Clover;
            //        break;
            //    default:
            //        returnCardType = CardType.None;
            //        break;
            //}

            return (CardType)valueType;
        }

        static string CheckCardName(int cardNumber)
        {
            int cardValue = ((cardNumber - 1) % 13) + 1;
            string cardName;
            switch (cardValue)
            {
                case 1:
                    cardName = "A";
                    break;
                case 11:
                    cardName = "J";
                    break;
                case 12:
                    cardName = "Q";
                    break;
                case 13:
                    cardName = "K";
                    break;
                default:
                    cardName = cardValue.ToString();
                    break;
            }

            return cardName;
        }




        static void Main(string[] args)
        {
            int[] deck = new int[52];

            Initialize(deck);

            Shuffle(deck);

            Print(deck);
        }
    }
}
