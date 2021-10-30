using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2 
{
    class Sedan : Car
    {
        public int manufacturerDiscount { get; set; }


        public Sedan(decimal speed, double regularPrice, string color, int manufacturerDiscount)
        {
            this.speed = speed;
            this.regularPrice = regularPrice;
            this.color = color;
            this.manufacturerDiscount = manufacturerDiscount;

        }

        public override double GetSalePrice()
        {
            return base.regularPrice - base.regularPrice * this.manufacturerDiscount/100;
        }


    }
}
