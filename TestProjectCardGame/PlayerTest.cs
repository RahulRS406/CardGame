using System.Collections.Generic;
using System.Linq;
using CardGame;
using NUnit.Framework;

namespace TestProjectCardGame
{

    

    [TestFixture]
    public class PlayerTest
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
            Player[] players = {testPlayer1, testPlayer2};

            CardGameHelpers.DistributeCards(players, deck);
        }

        [Test]
        public void AddToDiscardPile_AddsCards_PlayersDiscardPile()
        {
            Card card = testPlayer1.DrawCard();
            var beforeCount = testPlayer2.DiscardPile.Count;
            Assert.AreEqual(0, beforeCount);
            testPlayer2.AddToDiscardPile(new List<Card> {card});
            var afterCount = testPlayer2.DiscardPile.Count;
            Assert.AreEqual(1, afterCount);
        }

        [Test]
        public void DrawCard_ReturnsFirstCard_FromDrawPile()
        {
            var topmostCard = testPlayer1.DrawPile.First();
            Card card = testPlayer1.DrawCard();
            

            Assert.AreEqual(topmostCard, card);
        }

        [Test]
        public void DrawCard_WhenOnlyOneCardisRemainingInDrawPile_ShufflesDiscardPile()
        {
            var count= testPlayer1.DrawPile.Count;
            for (int i = 0; i < count - 1; i++)
            {
                Card card = testPlayer1.DrawCard();
                CardGameHelpers.RemoveCardFromPlayer(card, testPlayer1);
                    testPlayer1.AddToDiscardPile(new List<Card>{card});
            }

            Card atTheTopOfDiscardPile = testPlayer1.DiscardPile.First();
            Card lastCard = testPlayer1.DrawPile.Last();
            Card drawwnCard = testPlayer1.DrawCard();
            Card atTheTopOfDiscardPileAfterShuffle = testPlayer1.DiscardPile.First();



            Assert.AreNotEqual(atTheTopOfDiscardPile, atTheTopOfDiscardPileAfterShuffle);
            Assert.AreEqual(drawwnCard, lastCard);
        }

        [Test]
        public void WhenNoCardsOnDrawPile_DrawGetstheCard_FromDiscardPile()
        {
            var count = testPlayer1.DrawPile.Count;
            for (int i = 0; i < count ; i++)
            {
                Card card = testPlayer1.DrawCard();
                CardGameHelpers.RemoveCardFromPlayer(card, testPlayer1);
                testPlayer1.AddToDiscardPile(new List<Card> { card });
            }

            Card atTheTopOfDiscardPile = testPlayer1.DiscardPile.First();
            
            Card drawnCard = testPlayer1.DrawCard();



            Assert.AreEqual(drawnCard, atTheTopOfDiscardPile);
        }
    }
}