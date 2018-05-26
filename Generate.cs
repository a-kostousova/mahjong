using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    static class Generate
    {
        private static Random Random = new Random();

        public static Tuple<int, int> Coordinate(int length, int width) => Tuple.Create(Random.Next(length), Random.Next(width));

        public static Dice Dice()
        {
            var colorCount = Enum.GetValues(typeof(Colours)).Length;
            var picturesCount = Enum.GetValues(typeof(Pictures)).Length;
            return new Dice(
                (Colours)Random.Next(colorCount),
                (Pictures)Random.Next(picturesCount));
        }
    }
}
