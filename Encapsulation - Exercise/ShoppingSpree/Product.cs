using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {
		private string name;
        private decimal cost;

		public Product(string name, decimal cost)
		{
			Name = name;
			Cost = cost;
		}

		public string Name
		{
			get { return name; }
			private set { name = value; }
		}
	

		public decimal Cost
		{
			get { return cost; }
			private set { cost = value; }
		}





	}
}
