using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLinq
{
    class Card: IComparable<Card>
    {

        public int CompareTo(Card other)
        {
            return new CardComparerByValue().Compare(this, other);
        }

        public Values Value { get; set; }
        public Suits Suit { get; set; }
        public string Name { get { return $"{Value} of {Suit}"; } }

        public override string ToString()
        {
            return Name;
        }

        public Card(Values value, Suits suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

    }

    public enum Suits
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs,
    }

    public enum Values
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
