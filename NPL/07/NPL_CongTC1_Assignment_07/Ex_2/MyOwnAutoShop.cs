using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    class MyOwnAutoShop
    {
        static void Main(string[] args)
        {
            Sedan sedan = new Sedan(1, 1000, "Blue", 10);
            Ford ford1 = new Ford(2, 1000,"Black", 1996, 10);
            Ford ford2 = new Ford(2, 1000, "Pink", 1854, 30);
            Truck truck1 = new Truck(3, 1000, "Pink", 1000);
            Truck truck2 = new Truck(3, 1000, "Black", 3000);

            Console.WriteLine($"Sedan Price: {sedan.GetSalePrice()}");
            Console.WriteLine($"Ford 1 Price: {ford1.GetSalePrice()}");
            Console.WriteLine($"Ford 2 Price: {ford2.GetSalePrice()}");
            Console.WriteLine($"Truck 1 Price: {truck1.GetSalePrice()}");
            Console.WriteLine($"Truck 2 Price: {truck2.GetSalePrice()}");

            Console.ReadLine();
        }
    }
}
