using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class CardGameHelpers
    {
        
        public static void Compare(Card card1, Card card2, Player player1, Player player2)
        {
            if (card1.CardNumber > card2.CardNumber)
            {
                Console.WriteLine($"Player 1 ({player1.Name}) Wins this round");
                RemoveCardFromPlayer(card2, player2);
                AddCardToPlayer(new List<Card> { card2 }, player1);
            }

            if (card2.CardNumber > card1.CardNumber)
            {
                Console.WriteLine($"Player 2 ({player2.Name}) Wins this round");
                RemoveCardFromPlayer(card1, player1);
                AddCardToPlayer(new List<Card> { card1 }, player2);
            }

            if (card1.CardNumber == card2.CardNumber)
            {
                Console.WriteLine("None Wins this round");
                RemoveCardFromPlayer(card1, player1);

                RemoveCardFromPlayer(card2, player2);
            }
        }

        //internal static void AddClashCards(IList<Card> clashCards, Player player1)
        //{
        //    player1.A
        //}

        public static void RemoveCardFromPlayer(Card card, Player player)
        {
            if (player.DrawPile.Contains(card))
            {
                player.DrawPile.Remove(card);
            }
            else if (player.DiscardPile.Contains(card))
            {
                player.DiscardPile.Remove(card);
            }


        }

        public static void AddCardToPlayer(IList<Card> cards, Player player)
        {
            player.AddToDiscardPile(cards);
        }

        public static Player CheckWinner(Player player1, Player player2)
        {
            if (player1.DiscardPile.Count == 0 && player1.DrawPile.Count == 0)
            {
                return player2;
            }

            return player1;
        }

        public static bool Play(Player player1, Player player2)
        {
            if (player1.DrawPile.Count == 0 && player1.DiscardPile.Count == 0)
            {
                return false;
            }
            if (player2.DrawPile.Count == 0 && player2.DiscardPile.Count == 0)
            {
                return false;
            }

            return true;
        }



        public static void DistributeCards(Player[] players, Deck cards)
        {
            int j = 0;
            foreach (Player player in players)
            {
                for (int i = 0; i < 20; i++)
                {
                    player.DrawPile.Add(cards.Cards[j]);
                    j++;
                }
            }

        }
    }
}