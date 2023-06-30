using BirthdayCelebrations.Models;
using BorderControl.Models;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new();
            string[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (inputArgs[0] != "End")
            {
                switch (inputArgs[0])
                {
                    case "Citizen":
                        Citizen citizen = new(inputArgs[1], int.Parse(inputArgs[2]), long.Parse(inputArgs[3]), inputArgs[4]);
                        birthables.Add(citizen);
                        break;
                    case "Robot":
                        Robot robot = new(inputArgs[1], long.Parse(inputArgs[2]));
                        break;
                    case "Pet":
                        Pet pet = new(inputArgs[1], inputArgs[2]);
                        birthables.Add(pet);
                        break;
                }
                inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            string year = Console.ReadLine();
            foreach (var item in birthables)
            {
                if (item.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(item.BirthDate);
                }
            }
        }
    }
}