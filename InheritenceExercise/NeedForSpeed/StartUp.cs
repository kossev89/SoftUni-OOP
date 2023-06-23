namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(250, 400);
            sportCar.Drive(20);
            System.Console.WriteLine(sportCar.Fuel);
            FamilyCar family = new FamilyCar(320, 60);
            family.Drive(20);
            System.Console.WriteLine(family.Fuel);
            RaceMotorcycle motor = new RaceMotorcycle(500, 200);
            motor.Drive(50);
            System.Console.WriteLine(motor.Fuel);
            CrossMotorcycle cross = new CrossMotorcycle(200, 60);
            cross.Drive(20);
            System.Console.WriteLine(cross.Fuel);
        }
    }
}
