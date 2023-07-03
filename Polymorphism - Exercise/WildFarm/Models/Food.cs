using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Food
    {
		private int quantity;

		protected Food(int quantity)
		{
			this.quantity = quantity;
		}

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

	}
}
