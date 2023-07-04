using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double WeightGain = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
        public override void Eat(Food food, int quantity)
        {
            FoodEaten += quantity;
            Weight += quantity * WeightGain;
        }
    }
}
