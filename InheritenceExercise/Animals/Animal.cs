using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {

        private string name;

        private int age;

        private string sex;

        public Animal(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                sex = value;
            }
        }





        public virtual void ProduceSound()
        {
            Console.WriteLine("sound");
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{Name} {Age} {Sex}");
            return sb.ToString().Trim();
        }
    }
}
