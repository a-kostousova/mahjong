﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong
{
   public enum Colors
   {
        Blue,
        Red,
        Green,
        White,
        count
        //в конце каждого enumа будет поле count
        //так как оно в конце, то его числовое значение есть кол-во элементов в enume
   }

    public enum Pictures
    {
        one,
        two,
        three,
        four,
        five,
        count
    }
}
