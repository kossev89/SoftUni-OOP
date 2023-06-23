using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string sex) 
            : base(name, age, sex)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
