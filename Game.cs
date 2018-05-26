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
        private Tuple<int, int> ChosenDices;
        
        public Game(Field field) => Field = field;
        
        public Game(int length, int width, int count)
        {
            Field = new Field(length, width);
            Field.FillField(count);
        }
        
        private bool Takely(Tuple<int, int> coordinate) => Field[coordinate].Count != 0 &&
               (Field.Extreme(coordinate) || Field.Higher(coordinate));

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
                    MoveDicePointer(1, 0);
                    break;
                 case Keys.Enter:
                    ChooseDice();
                    break;
            }
        }

        private void MoveDicePointer(int dx, int dy) => DicePointer = Tuple.Create(
                SumMod(DicePointer.Item1, dx, Field.Length), 
                SumMod(DicePointer.Item2, dy, Field.Width));
        
        private int SumMod(int x, int y, int mod) => (x + y + mod) % mod;

        private void DeleteDices()
        {
            Field.Delete(DicePointer);
            Field.Delete(ChosenDice.Item2);
            ChosenDice = null;
            if (Field.PairCount == 0) Console.WriteLine("Game Over, You Win");
        }
        
        private void ChooseDice()
        {
            if (Takely(DicePointer))
                if (ChosenDice.Item1)
                {
                    if (ChosenDice == DicePointer) ChosenDice = null;
                    else if (Field[ChosenDice].Peek().Equals(Field[DicePointer].Peec())) DeleteDices();
                        else ChosenDice = null;
                }
                else ChosenDice = DicePointer;
        }
    }
}
