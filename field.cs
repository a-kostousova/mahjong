using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    class Field
    {
        private int Width { get { return columns.GetLength(0); } }
        private int Length { get { return columns.GetLength(1); } }
        private Stack<Dice>[,] Columns; //что это (я правда не очень понимаю)?

        public Field(int width, int length) //нормально, что имя совпадает с именем класса?
        {
            columns = new Stack<Dice>[width, length];
        }

        public void fuul(int count) //что тут должно быть?
        {
            for (var i = 0; i < count; i++)

        }


    }
}
