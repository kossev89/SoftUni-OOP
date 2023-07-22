using EDriveRent.Core.Contracts;
using EDriveRent.IO;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {

        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            Users = new();
            Vehicles = new();
            Routes = new();
        }

        public RouteRepository Routes
        {
            get { return routes; }
            set { routes = value; }
        }


        public VehicleRepository Vehicles
        {
            get { return vehicles; }
            private set { vehicles = value; }
        }


        public UserRepository Users
        {
            get { return users; }
            private set { users = value; }
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int currentId = Routes.GetAll().Count + 1;
            Route oldRoute = (Route)Routes.GetAll().Where(s => s.StartPoint == startPoint && s.EndPoint == endPoint).FirstOrDefault();
            

            if (oldRoute != null && oldRoute.Length==length)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            else if (oldRoute != null && oldRoute.Length < length)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            else if (oldRoute != null && oldRoute.Length > length)
            {
                Route route = new(startPoint, endPoint, length, currentId);
                Routes.AddModel(route);
                oldRoute.LockRoute();
                return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
            }
            else
            {
                Route route = new(startPoint, endPoint, length, currentId);
                Routes.AddModel(route);
                return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
            }
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            User currentUser = (User)Users.GetAll().FirstOrDefault(d => d.DrivingLicenseNumber == drivingLicenseNumber);
            Vehicle currentVehicle = (Vehicle)Vehicles.GetAll().FirstOrDefault(l => l.LicensePlateNumber == licensePlateNumber);
            Route currentRoute = (Route)Routes.GetAll().FirstOrDefault(i => i.RouteId == int.Parse(routeId));
            if (currentUser.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            else if (currentVehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            else if (currentRoute.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }
            else
            {
                currentVehicle.Drive(currentRoute.Length);
                if (isAccidentHappened)
                {
                    currentVehicle.ChangeStatus();
                    currentUser.DecreaseRating();
                }
                else
                {
                    currentUser.IncreaseRating();
                }
            }
            return currentVehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (Users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            else
            {
                User user = new(firstName, lastName, drivingLicenseNumber);
                Users.AddModel(user);
                return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            }
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> vehiclesToRepare = Vehicles.GetAll().Where(d => d.IsDamaged == true)
                .OrderBy(b => b.Brand).ThenBy(m => m.Model).Take(count).ToList();
            foreach (var vehicle in vehiclesToRepare)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, vehiclesToRepare.Count);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            else if (Vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            else
            {
                switch (vehicleType)
                {
                    case "PassengerCar":
                        PassengerCar passengerCar = new(brand, model, licensePlateNumber);
                        Vehicles.AddModel(passengerCar);
                        break;
                    case "CargoVan":
                        CargoVan cargoVan = new(brand, model, licensePlateNumber);
                        Vehicles.AddModel(cargoVan);
                        break;
                }
                return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }
        }

        public string UsersReport()
        {
            List<IUser> usersSorted = new();
            usersSorted = Users.GetAll().OrderByDescending(r => r.Rating).ThenBy(l => l.LastName)
                .ThenBy(f => f.FirstName).ToList();
            StringBuilder sb = new();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in usersSorted)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
