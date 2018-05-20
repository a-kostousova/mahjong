using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    class Field
    {
        public int Length { get => columns.GetLength(0); }
        public int Width { get => columns.GetLength(1); }
        private Stack<Dice>[,] columns;
        public int PairCount { get; private set; }

        public Field(int length, int width) => columns = new Stack<Dice>[length, width];

        private Tuple<int, int> GenerateCoordinate() => new Tuple<int, int>(new Random().Next(Length), new Random().Next(Width));

        //тут заполняю наше поле рандомными косточками, нужно назвать нормально только
        public void FillField(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var dice = new Dice().Generate();
                var coordinate = GenerateCoordinate();
                Push(coordinate, dice);
                ChangeTakableFeature(coordinate);
                var coordinate2 = GenerateCoordinate();
                //убеждаюсь, что новая координата не совпала с первой
                while (coordinate == coordinate2)
                    coordinate2 = GenerateCoordinate();
                Push(coordinate, dice);
                ChangeTakableFeature(coordinate2);
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
        private bool Higher(int x, int y) => columns[x - 1, y].Count < columns[x, y].Count || columns[x + 1, y].Count < columns[x, y].Count;

        private bool Extreme(int x) => x == 0 || x == Length - 1;

        public void Delete(Tuple<int, int> coordinate)
        {
            this[coordinate].Pop();
            ChangeTakableFeature(coordinate);
            PairCount--;
        }

        public void Push(Tuple<int, int> coordinate, Dice dice) => this[coordinate].Push(dice);

        public Stack<Dice> this[Tuple<int, int> coordinate] { get => columns[coordinate.Item1, coordinate.Item2]; }
    }
}
