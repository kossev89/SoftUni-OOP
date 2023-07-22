using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            this.routes = new List<IRoute> { };
        }

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            IRoute routeFound = routes.FirstOrDefault(r => r.RouteId.ToString() == identifier);
            return routeFound;
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            IReadOnlyCollection<IRoute> routesCopy = routes;
            return routesCopy;
        }

        public bool RemoveById(string identifier)
        {
            IRoute routeToRemove = routes.FirstOrDefault(r => r.RouteId.ToString() == identifier);
            if (routeToRemove!=default)
            {
                routes.Remove(routeToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
