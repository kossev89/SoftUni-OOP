using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefaultSex = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, DefaultSex)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
