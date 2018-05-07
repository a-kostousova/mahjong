using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mahjong
{
    class Game 
    {
        private Field Field;
        private Tuple<int, int> DicePointer;
        private Tuple<Dice, Dice> ChosenDices;

        public void PressKey(Keys key)
        {
            switch (key)
            {
                case Keys.Down:
                    MoveDicePointer(0, -1);
                    break;
                case Keys.Up:
                    MoveDicePointer(0, 1);
                    break;
                case Keys.Left:
                    MoveDicePointer(-1, 0);
                    break;
                case Keys.Right:
                    MoveDicePointer(0, 1);
                    break;
            }
        }

        private void MoveDicePointer(int dx, int dy) => DicePointer = Tuple.Create(
                SumMod(DicePointer.Item1, dx, Field.Length), 
                SumMod(DicePointer.Item2, dy, Field.Width));
        private int SumMod(int x, int y, int mod) => (x + y + mod) % mod;

        //private void 
    }
}
