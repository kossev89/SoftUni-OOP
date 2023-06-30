using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen: IIdentifiable
    {
        public Citizen(string name, int age, long iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public long ID { get; set; }
    }
}
