using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private IReadOnlyCollection<IDelicacy> models;
        readonly List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
            Models = delicacies;
        }

        public IReadOnlyCollection<IDelicacy> Models 
        { 
            get => models; 
            private set
            {
                models = delicacies;
            }
        }

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
