using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player 1 Name: ");
            Player player1 = new Player(Console.ReadLine());

            Console.WriteLine("Enter Player 2 Name: ");
            Player player2 = new Player(Console.ReadLine());

            Deck deck = new Deck();

            Player[] players = { player2, player1 };
            IList<Card> clashCards = new List<Card>();

            CardGameHelpers.DistributeCards(players, deck);
            bool isCardsClashed = false;

            while (CardGameHelpers.Play(player1, player2))
            {

                Card card1 = player1.DrawCard();
                Console.WriteLine($"Player 1 ({player1.Name}) ({player1.DrawPile.Count + player1.DiscardPile.Count -1} cards): {card1.CardNumber}");

                Card card2 = player2.DrawCard();
                Console.WriteLine($"Player 2 ({player2.Name}) ({player2.DrawPile.Count + player2.DiscardPile.Count -1} cards): {card2.CardNumber}");


                if (card1.CardNumber == card2.CardNumber)
                {
                    clashCards.Add(card1);
                    clashCards.Add(card2);
                    isCardsClashed = true;
                    CardGameHelpers.RemoveCardFromPlayer(card1, player1);
                    CardGameHelpers.RemoveCardFromPlayer(card2, player2);
                }
                else
                {
                    if (isCardsClashed)
                    {
                        if (card1.CardNumber > card2.CardNumber)
                            CardGameHelpers.AddCardToPlayer(clashCards, player1);
                        else if (card2.CardNumber > card1.CardNumber)
                        {
                            CardGameHelpers.AddCardToPlayer(clashCards, player2);
                        }
                        isCardsClashed = false;
                        clashCards.Clear();
                    }
                    CardGameHelpers.Compare(card1, card2, player1, player2);
                }
            }

            Player winner = CardGameHelpers.CheckWinner(player1, player2);
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine($"Number of Cards with {player1.Name} : {player1.DrawPile.Count + player1.DiscardPile.Count}");
            Console.WriteLine($"Number of Cards with {player2.Name} : {player2.DrawPile.Count + player2.DiscardPile.Count}");
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine($"{winner.Name} wins this game");

        }

    }
}
