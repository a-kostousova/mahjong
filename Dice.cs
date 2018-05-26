﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahjong
{
    public enum Colours
    {
        Blue,
        Red,
        Green,
        White,
    }

    public enum Pictures
    {
        one,
        two,
        three,
        four,
        five,
    }
    public class Dice
    {
        public Colours Colour;
        public Pictures Picture;

        public Dice() => new Dice();

        public Dice(Colours colour, Pictures picture)
        {
            Colour = colour;
            Picture = picture;
        }

        public bool Equals(Dice dice) => EqualsColours(dice) && EqualsPictures(dice);
        public bool EqualsPictures(Dice dice) => Picture == dice.Picture;
        public bool EqualsColours(Dice dice) => Colour == dice.Colour;

        //именно для этого нужно поле count
        //теперь можно добавлять новые поля в каждый из enumов и не пересчитывать их кол-во вручную 
    }
}
