using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Animal
    {
		private string name;
        private double weight;
        private int foodEaten;

		protected Animal(string name, double weight)
		{
			this.name = name;
			this.weight = weight;
			this.foodEaten = 0;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public int FoodEaten
		{
			get { return foodEaten; }
			set { foodEaten = value; }
		}


		public virtual void AskForFood()
		{

		}

		public virtual void Eat(Food food, int quantity)
		{

		}
		


	}
}
