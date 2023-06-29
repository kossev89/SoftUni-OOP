using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private const int baseModifier = 2;
        private double doughModifier;
        private double techModifier;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            DoughModifier = doughModifier;
            TechModifier = techModifier;
        }

        private double TechModifier
        {
            get { return techModifier; }
            set
            {
                switch (bakingTechnique)
                {
                    case "crispy":
                        techModifier = 0.9;
                        break;
                    case "chewy":
                        techModifier = 1.1;
                        break;
                    case "homemade":
                        techModifier = 1.0;
                        break;
                }
            }
        }


        public double CaloriesPerGram
        {
            get => baseModifier * doughModifier * techModifier;
        }


        private double DoughModifier
        {
            get { return doughModifier; }
            set
            {
                switch (flourType)
                {
                    case "white":
                        doughModifier = 1.5;
                        break;
                    case "wholegrain":
                        doughModifier = 1.0;
                        break;
                }
            }
        }


        private int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }


        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() == "crispy"
                    || value.ToLower() == "chewy"
                    || value.ToLower() == "homemade"
                    )
                {
                    bakingTechnique = value.ToLower();
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }


        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() == "white"
                    || value.ToLower() == "wholegrain"
                    )
                {
                    flourType = value.ToLower();
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double CalculateCalories()
        {
            double totalCalories = this.weight * this.CaloriesPerGram;
            return totalCalories;
        }

    }
}
