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
                Executable(coordinate);
                var coordinate2 = GenerateCoordinate();
                //убеждаюсь, что новая координата не совпала с первой
                while (coordinate == coordinate2)
                    coordinate2 = GenerateCoordinate();
                Push(coordinate, dice);
                Executable(coordinate2);
            }
        }
        
        private void Executable(Tuple<int, int> coordinate)
        {
            var x = coordinate.Item1;
            var y = coordinate.Item2;
            for (var dx = -1; dx <= 1; dx++)
            {
                if (columns[x + dx, y].Count == 0) continue;
                if (Crainij(x + dx) || LessThanOneAnother(x + dx, y)) columns[x + dx, y].Peek().Executable = true;
                else columns[x + dx, y].Peek().Executable = false;
            }
        }
        private bool LessThanOneAnother(int x, int y) => columns[x - 1, y].Count < columns[x, y].Count || columns[x + 1, y].Count < columns[x, y].Count;

        private bool Crainij(int x) => x == 0 || x == Length - 1;

        public void Delete(Tuple<int, int> coordinate)
        {
            this[coordinate].Pop();
            Executable(coordinate);
        }

        public void Push(Tuple<int, int> coordinate, Dice dice) => this[coordinate].Push(dice);

        private Stack<Dice> this[Tuple<int, int> coordinate] { get => columns[coordinate.Item1, coordinate.Item2]; }
    }
}
