using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository() 
        {
            students=new();
            models = students;
        }
        private IReadOnlyCollection<IStudent> models;
        private List<IStudent> students;

        public IReadOnlyCollection<IStudent> Models
        {
            get => models;
            private set
            {
                Models = students;
            }
        }

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)
        {
            return students.Find(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = fullName[0];
            string lastName = fullName[1];
            return students.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);
        }
    }
}
