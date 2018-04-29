using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong
{
    public class Dice
    {
        public Colors Color;
        public Pictures Picture;

        public Dice() => new Dice();

        public Dice(Colors color, Pictures picture)
        {
            Color = color;
            Picture = picture;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Dice)) return false;
            var dice = obj as Dice;
            if (dice.Color != Color || dice.Picture != Picture) return false;
            return true;
        }

        //именно для этого нужно поле count
        //теперь можно добавлять новые поля в каждый из enumов и не пересчитывать их кол-во вручную
        public Dice Generate() => new Dice(
            (Colors)new Random().Next((int)Colors.count - 1), 
            (Pictures)new Random().Next((int)Pictures.count - 1));
        
    }
}
