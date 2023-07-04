using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(Food food, int quantity)
        {
            if (food is Fruit
                || food is Vegetable)
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
