using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }   

        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            IVehicle vehicleFound = vehicles.FirstOrDefault(x => x.LicensePlateNumber == identifier);
            return vehicleFound;
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            IReadOnlyCollection<IVehicle> vehiclesCopy = vehicles;
            return vehiclesCopy;
        }

        public bool RemoveById(string identifier)
        {
            IVehicle vehicleToRemove = vehicles.FirstOrDefault(x=>x.LicensePlateNumber == identifier);
            if (vehicleToRemove!=default)
            {
                vehicles.Remove(vehicleToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
