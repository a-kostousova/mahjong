using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    class Field
    {
        private int width { get { return columns.GetLength(0); } }
        private int length { get { return columns.GetLength(1); } }
        private Stack<Dice>[,] columns;

        public Field(int width, int length) => 
            columns = new Stack<Dice>[width, length];

        Tuple<int, int> GenerateCoordinate() => 
            new Tuple<int, int>(new Random().Next(width), new Random().Next(length));

        //тут заполняю наше поле рандомными косточками, нужно назвать нормально только
        public void fuul(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var dice = new Dice().Generate();
                var coordinate = GenerateCoordinate();
                columns[coordinate.Item1, coordinate.Item2].Push(dice);
                var coordinate2 = GenerateCoordinate();
                //убеждаюсь, что новая координата не совпала с первой
                while (coordinate == coordinate2)
                    coordinate2 = GenerateCoordinate();
                columns[coordinate2.Item1, coordinate2.Item2].Push(dice);
            }
        }
    }
}
