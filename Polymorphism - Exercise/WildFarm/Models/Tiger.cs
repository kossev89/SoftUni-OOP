using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double WeightGain = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
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
