using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public double Caffeine { get; set; }
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, decimal price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        public override double Milliliters => CoffeeMilliliters;
        public override decimal Price => CoffeePrice;


    }
}
