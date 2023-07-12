using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
        private string corps;

        public string Corps
        {
            get { return corps; }
            set 
            {
                if (value == "Airforces" || value == "Marines" && string.IsNullOrEmpty(value))
                {
                    corps = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
