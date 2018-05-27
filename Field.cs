using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongApp
{
    class Field
    {
        public int Length { get => columns.GetLength(0); }
        public int Width { get => columns.GetLength(1); }
        private Stack<Dice>[,] columns;
        public int PairCount { get; private set; }

        public Field(int length, int width) => columns = new Stack<Dice>[length, width];

        private Tuple<int, int> GenerateCoordinate() => new Tuple<int, int>(new Random().Next(Length), new Random().Next(Width));

        //тут заполняю наше поле рандомными косточками
        public void FillField(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var dice = Generate.Dice();
                var coordinate = Generate.Coordinate(Length, Width);
                Push(coordinate, dice);
                var coordinate2 = Generate.Coordinate(Length, Width);
                //убеждаюсь, что новая координата не совпала с первой
                while (coordinate == coordinate2)
                    coordinate2 = GenerateCoordinate();
                Push(coordinate, dice);
            }
        }

        private void ChangeTakableFeature(Tuple<int, int> coordinate)
        {
            var x = coordinate.Item1;
            var y = coordinate.Item2;
            for (var dx = -1; dx <= 1; dx++)
            {
                if (columns[x + dx, y].Count == 0) continue;
                if (Extreme(x + dx) || Higher(x + dx, y)) columns[x + dx, y].Peek().Takable = true;
                else columns[x + dx, y].Peek().Takable = false;
            }
        }
        private bool Higher(Tuple<int, int> coordinate)
        {
            var x = coordinate.Item1;
            var y = coordinate.Item2;
            return columns[x - 1, y].Count < this[coordinate].Count || columns[x + 1, y].Count < this[coordinate].Count;
        }

        private bool Extreme(Tuple<int, int> coordinate) => coordinate.Item1 == 0 || coordinate.Item1 == Length - 1;

        public void Delete(Tuple<int, int> coordinate)
        {
            this[coordinate].Pop();
            PairCount--;
        }

        public void Push(Tuple<int, int> coordinate, Dice dice) => this[coordinate].Push(dice);

        public Stack<Dice> this[Tuple<int, int> coordinate] { get => columns[coordinate.Item1, coordinate.Item2]; }
    }
}