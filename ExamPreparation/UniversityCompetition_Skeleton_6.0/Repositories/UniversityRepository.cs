using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository() 
        {
            universities = new();
            models = universities;
        }
        private IReadOnlyCollection<IUniversity> models;
        private List<IUniversity> universities;

        public IReadOnlyCollection<IUniversity> Models 
        { 
            get => models; 
            private set => models = universities; 
        }

        public void AddModel(IUniversity model)
        {
            universities.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return universities.Find(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.Find(x => x.Name == name);
        }
    }
}
