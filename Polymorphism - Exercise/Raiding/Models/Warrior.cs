using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    internal class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            Power = 100;
        }
        public override string CastAbility()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} - {Name} hit for {Power} damage");
            return sb.ToString().Trim();
        }
    }
}
