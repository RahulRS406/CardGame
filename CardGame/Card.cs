using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum Suit
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }
    //Making the following class as public as I am using a different project for UTs otherwise we can make it internal
    public class Card
    {
        public Suit Suit { get; private set; }
        public int CardNumber { get; private set; }
        public Card(Suit suit,int cardNumber)
        {
            this.Suit = suit;
            this.CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return $"Suit is {Suit} and Card Number is {CardNumber}";
        }
    }
}
