using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            Squad = new HashSet<IPrivate>();
        }

        public HashSet<IPrivate> Squad { get; private set; }
        public void AddPrivate(Private @private)
        {
            Squad.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Id}");
            sb.AppendLine("Privates:");
            foreach (var @private in Squad)
            {
                sb.AppendLine(@private.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
