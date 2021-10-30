using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    class Truck : Car
    {

        public int weight { get; set; }

        public Truck(decimal speed, double regularPrice, string color, int weight)
        {
            this.speed = speed;
            this.regularPrice = regularPrice;
            this.color = color;
            this.weight = weight;
        }

        public override double GetSalePrice()
        {
            return this.weight > 2000 ? base.regularPrice - base.regularPrice * 0.1 : base.regularPrice - base.regularPrice * 0.2;
        }


    }
}
