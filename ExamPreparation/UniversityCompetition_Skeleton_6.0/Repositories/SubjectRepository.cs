using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository() 
        {
            modelsCopy = new();
            models = modelsCopy;
        }
        private List<ISubject> modelsCopy;
        private IReadOnlyCollection<ISubject> models;

        public IReadOnlyCollection<ISubject> Models 
        { 
            get => models; 
            private set => models = modelsCopy; 
        }

        public void AddModel(ISubject model)
        {
            modelsCopy.Add(model);
        }

        public ISubject FindById(int id)
        {
            return modelsCopy.Find(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return modelsCopy.Find(x => x.Name == name);
        }
    }
}
