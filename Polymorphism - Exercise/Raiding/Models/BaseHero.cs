using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        public BaseHero(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public virtual string CastAbility()
        {
            StringBuilder sb = new();
            return sb.ToString().Trim();
        }

    }
}
