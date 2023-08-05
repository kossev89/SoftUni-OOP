using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private IReadOnlyCollection<ICocktail> models;
        readonly List<ICocktail> cocktails;
        public CocktailRepository()
        {
            cocktails = new List<ICocktail> { };
            Models = cocktails;
        }
        public IReadOnlyCollection<ICocktail> Models 
        { 
            get => models; 
            private set
            {
                models = cocktails;
            }
        }

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
