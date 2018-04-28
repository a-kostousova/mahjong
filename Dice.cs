using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    public class Dice
    {
        public Colours Colour;
        public Numbers Number;

        public Dice(Colours colour, Numbers number)
        {
            Colour = colour;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Dice)) return false;
            var dice = obj as Dice;
            if (dice.Colour != Colour || dice.Number != Number) return false;
            return true;
        }

        public Dice Generate()
        {

        }

    }
}
