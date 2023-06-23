using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class Kitten : Cat
    {
        private const string DefaultSex = "Female";
        public Kitten(string name, int age, string sex) 
            : base(name, age, DefaultSex)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
