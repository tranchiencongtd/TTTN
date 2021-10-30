using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    class Ford : Car
    {
        public int year { get; set; }

        public int length { get; set; }

        public Ford(decimal speed, double regularPrice, string color, int year, int length)
        {
            this.speed = speed;
            this.regularPrice = regularPrice;
            this.color = color;
            this.year = year;
            this.length = length;
        }

        public override double GetSalePrice()
        {
            return length > 20 ? base.regularPrice - base.regularPrice * 0.05 : base.regularPrice - base.regularPrice * 0.1;
        }



    }
}
