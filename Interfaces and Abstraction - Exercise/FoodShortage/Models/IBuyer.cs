using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public interface IBuyer
    {
        public const int foodBought = 0;
        public int Food { get; set; }

    void BuyFood()
        {
            //Food += foodBought;
        }
    }
}
