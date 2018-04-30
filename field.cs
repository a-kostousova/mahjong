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

        public Field(int length, int width) => columns = new Stack<Dice>[length, width];

        private Tuple<int, int> GenerateCoordinate() => new Tuple<int, int>(new Random().Next(Length), new Random().Next(Width));

        //тут заполняю наше поле рандомными косточками, нужно назвать нормально только
        public void Fuul(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var dice = new Dice().Generate();
                var coordinate = GenerateCoordinate();
                Push(coordinate, dice);
                Executable(coordinate, false);
                var coordinate2 = GenerateCoordinate();
                //убеждаюсь, что новая координата не совпала с первой
                while (coordinate == coordinate2)
                    coordinate2 = GenerateCoordinate();
                Push(coordinate, dice);
                Executable(coordinate2, false);
            }
        }
        
        void Executable(int x, int y)
        {
            if (x == 0 || x == width || y == 0 || y == length) columns[x, y].Peek().Executable = true;
            else if (columns[x - 1, y].Count < columns[x, y].Count ||
                     columns[x + 1, y].Count < columns[x, y].Count ||
                     columns[x, y - 1].Count < columns[x, y].Count ||
                     columns[x, y + 1].Count < columns[x, y].Count)
                     columns[x, y].Peek().Executable = true;
        }

        void Executable(Tuple<int, int> coordinate, bool isNeighbor)
        {
            var x = coordinate.Item1;
            var y = coordinate.Item2;
            Executable(x, y);
            if (!isNeighbor)
            {
                if (x != 0) Executable(Tuple.Create(x - 1, y), true);
                if (x != Length - 1) Executable(Tuple.Create(x + 1, y), true);
                if (y != 0) Executable(Tuple.Create(x, y - 1), true);
                if (y != Width - 1) Executable(Tuple.Create(x, y + 1), true);
            }
        }

        public void Delete(Tuple<int, int> coordinate)
        {
            columns[coordinate.Item1, coordinate.Item2].Pop();
            Executable(coordinate, false);
        }

        public void Push(Tuple<int, int> coordinate, Dice value) => this[coordinate].Push(value);

        private Stack<Dice> this[Tuple<int, int> coordinate] { get => columns[coordinate.Item1, coordinate.Item2]; }
    }
}
