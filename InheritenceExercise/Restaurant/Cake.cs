using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {

        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
        }
        public override double Grams => 250;
        public override double Calories => 1000;
        public override decimal Price => 5m;
    }
}
