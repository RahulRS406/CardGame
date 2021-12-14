using System;
using System.Linq;
using CardGame;
using NUnit.Framework;

namespace TestProjectCardGame
{
    [TestFixture]
    public class ShuffleCardsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenDeckIsCreated_ItCreates_40Cards()
        {
            Deck deck = new Deck();
            Assert.AreEqual(deck.Cards.Count, 40);
        }

        [Test]
        public void DeckWhenShuffledItShufflesCards()
        {
            //There is 1/40 probability that this may fail
                Random random = new Random();
                int nums = random.Next(1, 40);
                Deck deck = new Deck();
                var firstCard = deck.Cards[nums];
                var shuffledCards = deck.Cards.ToList().Shuffle();
                var firstCardAfterShuffle = shuffledCards[nums];
                Assert.IsTrue(firstCard.CardNumber != firstCardAfterShuffle.CardNumber);
        }
    }
}