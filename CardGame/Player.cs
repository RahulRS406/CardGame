using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public IList<Card> DrawPile { get; private set; }
        public IList<Card> DiscardPile { get; private set; }
        public string Name { get; set; }

        public Player(string name)
        {
            DrawPile = new List<Card>();
            Name = name;
            DiscardPile = new List<Card>();
        }

        public void AddToDiscardPile(IList<Card> cards)
        {
            foreach (var card in cards) DiscardPile.Add(card);
        }

        public Card DrawCard()
        {
            if (DrawPile.Any() && DrawPile.Count>1)
            {
                return DrawPile.First();
            }
            if(DrawPile.Count==1)
            {
                //This is just to make sure that shuffle should happen only once i.e when only one card is left at 
                //Draw pile and next turn to draw is from Discard
                DiscardPile = DiscardPile.Shuffle();
                return DrawPile.First();
            }
            if (DrawPile.Count == 0 && DiscardPile.Any())
            {
                DrawPile = DiscardPile;
                return DrawPile.First();
            }

            return default;
        }
    }
}
