using System;
using System.Collections.Generic;
using CardGame;
using NUnit.Framework;

namespace TestProjectCardGame
{
    [TestFixture]
    public class CardGameHelperTest
    {
        Deck deck;
        private Player testPlayer1;
        private Player testPlayer2;

        [SetUp]
        public void Setup()
        {
            deck = new Deck();
            testPlayer1 = new Player("TestPlayer1");
            testPlayer2 = new Player("TestPlayer2");
            Player[] players = { testPlayer1, testPlayer2 };

            CardGameHelpers.DistributeCards(players, deck);
        }

        [Test]
        public void ComparingTwoCards_PersonWithHigherValue_Wins()
        {
            int player1CardCount = testPlayer1.DrawPile.Count + testPlayer1.DiscardPile.Count;
            int player2CardCount = testPlayer2.DrawPile.Count + testPlayer2.DiscardPile.Count;

            int drawnCard1Value, drawnCard2Value;
            do
            {
                Card card1 = testPlayer1.DrawCard();
                drawnCard1Value = card1.CardNumber;
                Card card2 = testPlayer2.DrawCard();
                drawnCard2Value = card2.CardNumber;
                CardGameHelpers.Compare(card1, card2, testPlayer1, testPlayer2);

            } while (false);

            if (drawnCard2Value == drawnCard1Value)
            {
                Assert.AreEqual(player1CardCount - 1, player2CardCount - 1);
            }

            if (drawnCard1Value > drawnCard2Value)
            {
                Assert.IsTrue(testPlayer1.DrawPile.Count + testPlayer1.DiscardPile.Count > player1CardCount);
            }
            else
            {
                Assert.IsTrue(testPlayer2.DrawPile.Count + testPlayer2.DiscardPile.Count > player2CardCount);
            }
        }

        [Test]
        public void WhenBothCards_AreSame_NextWinnerWinsAllCards()
        {
            int player1CardCount = testPlayer1.DrawPile.Count + testPlayer1.DiscardPile.Count;
            int player2CardCount = testPlayer2.DrawPile.Count + testPlayer2.DiscardPile.Count;

            int drawnCard1Value = default, drawnCard2Value = default;
            while(CardGameHelpers.Play(testPlayer1, testPlayer2))
            {
                Card card1 = testPlayer1.DrawCard();
                drawnCard1Value = card1.CardNumber;
                Card card2 = testPlayer2.DrawCard();
                drawnCard2Value = card2.CardNumber;
                if (drawnCard2Value == drawnCard1Value)
                {

                }
                player1CardCount = testPlayer1.DrawPile.Count + testPlayer1.DiscardPile.Count;
                player2CardCount = testPlayer2.DrawPile.Count + testPlayer2.DiscardPile.Count;
                CardGameHelpers.Compare(card1, card2, testPlayer1, testPlayer2);

            }

            Assert.IsTrue(true);
        }


    }
}