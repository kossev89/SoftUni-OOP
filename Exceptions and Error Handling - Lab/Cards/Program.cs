
using System;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new();
            string[] cardInfo = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in cardInfo)
            {
                string face = string.Empty;
                string suit = string.Empty;
                string[] faceSuit = item
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                face = faceSuit[0].ToString().ToUpper();
                suit = faceSuit[1].ToString().ToUpper();
                try
                {
                    Card card = CreateCard(face, suit);
                    deck.Add(card);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(' ', deck));


        }
        internal class Card
        {
            public Card(string face, string suit)
            {
                Face = face;
                Suit = suit;
            }

            public string Face { get; set; }
            public string Suit { get; set; }

            public override string ToString()
            {
                return $"[{Face}{Suit}]";
            }
        }
        static Card CreateCard(string face, string suit)
        {
            string[] validFaces = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuit = new[] { "S", "H", "D", "C" };

            if (validFaces.Contains(face) && validSuit.Contains(suit))
            {
                string icon = string.Empty;

                switch (suit)
                {
                    case "S":
                        icon = "\u2660";
                        break;
                    case "H":
                        icon = "\u2665";
                        break;
                    case "D":
                        icon = "\u2666";
                        break;
                    case "C":
                        icon = "\u2663";
                        break;

                }

                Card card = new(face, icon);
                return card;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
}