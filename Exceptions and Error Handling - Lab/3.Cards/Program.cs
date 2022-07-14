using System;
using System.Collections.Generic;

namespace _3.Cards
{
   
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string input = Console.ReadLine();
            string[] combinations = input.Split(", ");

            foreach (string combination in combinations)
            {
                string[] symbols = combination.Split();
                string currFace = symbols[0];
                string currSuit = symbols[1];

                try
                {
                    Card card = new Card(currFace, currSuit);
                    card.CreateCard(currFace, currSuit);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));

        }
    }
}
