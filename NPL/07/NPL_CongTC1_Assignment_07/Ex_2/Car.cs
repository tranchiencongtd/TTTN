using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    public abstract class Car
    {
        public decimal speed { get; set; }
        public double regularPrice { get; set; }
        public string color { get; set; }

        public abstract double GetSalePrice();

        
    }

}
