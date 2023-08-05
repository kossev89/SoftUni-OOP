using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private IReadOnlyCollection<IBooth> models;
        private List<IBooth> booths;
        public BoothRepository()
        {
            booths = new List<IBooth>();
            Models = booths;
        }
        public IReadOnlyCollection<IBooth> Models 
        { 
            get => models;
            private set
            {
                models = booths;
            }
        }

        public void AddModel(IBooth model)
        {
            booths.Add(model);
        }
    }
}
