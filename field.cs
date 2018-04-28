using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong
{
    class field
    {
        private int width { get { return columns.GetLength(0); } }
        private int length { get { return columns.GetLength(1); } }
        private Stack<Dice>[,] columns;

        public field(int width, int length)
        {
            columns = new Stack<Dice>[width, length];
        }

        public void fuul(int count)
        {
            for (var i = 0; i < count; i++)

        }


    }
}
