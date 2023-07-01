using BirthdayCelebrations.Models;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen: IIdentifiable, IBirthable, IBuyer
    {
        private const int foodBought = 10;
        public Citizen(string name, int age, long iD, string birthDate)
        {
            Name = name;
            Age = age;
            ID = iD;
            BirthDate = birthDate;
            Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public long ID { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += foodBought;
        }
    }
}
