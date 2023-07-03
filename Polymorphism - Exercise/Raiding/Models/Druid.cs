using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            Power = 80;
        }
        public override string CastAbility()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} - {Name} healed for {Power}");
            return sb.ToString().Trim();
        }
    }
}
