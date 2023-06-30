using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new();
        }
        public int NumberOfToppings
        {
            get => toppings.Count;
        }
        public double TotalCalories
        {
            get => CalculateCalories();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value == string.Empty
                    || value == null
                    || value.Length > 15
                    || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            private set
            {
                toppings = value;
            }
        }

        private double CalculateCalories()
        {
            double totalCalories = dough.CalculateCalories();
            foreach (var item in toppings)
            {
                totalCalories += item.CalculateCalories();
            }
            return totalCalories;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{name} - {TotalCalories:f2} Calories.";
        }
    }
}
