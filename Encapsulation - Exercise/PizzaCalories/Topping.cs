using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
		private int weight;
		private const double baseCalories = 2;
        private double modifier;
        private string type;


        public int Weight
		{
			get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50]");
                }
                weight = value;
            }
        }
        // to do

		public double Modifier
		{
			get { return modifier; }
			private set
			{
                switch (type)
                {
                    case "meat":
                        modifier = 1.2;
                        break;
                    case "veggies":
                        modifier = 0.8;
                        break;
                    case "cheese":
                        modifier = 1.1;
                        break;
                    case "sauce":
                        modifier = 0.9;
                        break;
                }
            }
		}


		public string Type
		{
			get { return type; }
			private set 
			{
                if (value == "meat"
                   || value == "veggies"
                   || value == "cheese"
				   || value == "sauce"
                   )
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
		}

        public double CaloriesPerGram
        {
			get => baseCalories * modifier;
        }



    }
}
