using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    //Making the following class as public as I am using a different project for UTs otherwise we can make it internal
    public class Deck
    {
        public readonly IList<Card> Cards = new List<Card>();

        public Deck()
        {
            //CreateShuffledDeck();
            ConstructDeck();
            ShuffledDeck();
        }

        private  void ConstructDeck()
        {
            AddHeart();
            AddSpade();
            AddDiamond();
            AddClubs();

        }

        private  void AddHeart()
        {
            CreateCards(Suit.Hearts);
        }

        private  void AddSpade()
        {
            CreateCards(Suit.Spades);
        }

        private  void AddDiamond()
        {
            CreateCards(Suit.Diamonds);
        }

        private void AddClubs()
        {
            CreateCards(Suit.Clubs);
        }

        private void CreateCards(Suit cardSuit)
        {
            for (int i = 1; i <= 10; i++)
            {
                this.Cards.Add(new Card(cardSuit, i));
            }
        }

        private void ShuffledDeck()
        {
            Cards.Shuffle();
        }
    }
}
