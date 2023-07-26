using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements = new();
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements;
        }

        public bool RemoveByName(string typeName)
        {
            return supplements.Remove(supplements.FirstOrDefault(x => x.GetType().Name == typeName));
        }
    }
}
