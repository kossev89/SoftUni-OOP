using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (name == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public void Purchase(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            List<string> productNames = new();
            foreach (Product product in Products)
            {
                productNames.Add(product.Name);
            }

            if (products.Count > 0)
            {
                return $"{Name} - {string.Join(", ", productNames)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }


    }
}
