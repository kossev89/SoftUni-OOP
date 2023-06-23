using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaultGrams = 250;
        private const decimal DefaultPrice = 5m;
        private const double DefaultCalories = 1000;
        public Cake(string name, decimal price, double grams, double calories) 
            : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
