using Vehicles.Models;

namespace Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            string[] carInfo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Drive")
                {
                    switch (command[1])
                    {
                        case "Car":
                            car.Drive(double.Parse(command[2]));
                            break;
                        case "Truck":
                            truck.Drive(double.Parse(command[2]));
                            break;
                        case "Bus":
                            bus.Drive(double.Parse(command[2]));
                            break;
                    }
                }
                else if (command[0] == "Refuel")
                {
                    switch (command[1])
                    {
                        case "Car":
                            car.Refuel(double.Parse(command[2]));
                            break;
                        case "Truck":
                            truck.Refuel(double.Parse(command[2]));
                            break;
                        case "Bus":
                            bus.Refuel(double.Parse(command[2]));
                            break;
                    }
                }
                else
                {
                    bus.DriveEmpty(double.Parse(command[2]));
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}