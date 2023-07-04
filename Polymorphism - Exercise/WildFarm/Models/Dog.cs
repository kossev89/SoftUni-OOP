using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double WeightGain = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
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
