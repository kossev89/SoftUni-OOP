using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen: IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, long iD, string birthDate)
        {
            Name = name;
            Age = age;
            ID = iD;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public long ID { get; set; }
        public string BirthDate { get; set; }
    }
}
