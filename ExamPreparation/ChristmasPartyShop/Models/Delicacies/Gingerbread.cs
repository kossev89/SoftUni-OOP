using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double defaultPrice = 4.00;
        public Gingerbread(string name) : base(name, defaultPrice)
        {
        }
    }
}
