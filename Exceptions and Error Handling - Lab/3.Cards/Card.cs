using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Cards
{
    public class Card
    {
        private readonly List<string> faces = new List<string>()
        {
           "2","3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };
        private readonly List<string> suits = new List<string>()
        {
           "S", "H", "D", "C"
        };

        public string Face { get; set; }

        public string Suit { get; set; }

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public Card CreateCard(string face,string suit)
        {
            if (!faces.Contains(face))
            {
                throw new Exception("Invalid card!");
            }

            if (suit == "S")
            {
                this.Suit = "\u2660";
            }
            else if (suit == "H")
            {
                this.Suit = "\u2665";
            }
            else if (suit == "D")
            {
                this.Suit = "\u2666";
            }
            else if (suit == "C")
            {
                this.Suit = "\u2663";
            }
            else
            {
                throw new Exception("Invalid card!");
            }

            Card card = new Card(face, suit);
            return card;
        }
        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
