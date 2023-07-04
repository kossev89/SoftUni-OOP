using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(Food food, int quantity)
        {
            if (food is Meat)
            {
                FoodEaten += quantity;
                Weight += quantity * WeightGain;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
