using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;

        public Person()
        {
        }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Age
        {
            get
            {
                if (age >= 0)
                {
                    return age;
                }
                else
                {
                    return default;
                }
            }
            set
            { Age = value; }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
