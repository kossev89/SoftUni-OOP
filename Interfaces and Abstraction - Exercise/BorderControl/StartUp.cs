using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new();
            string[] infoArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (infoArgs[0] != "End")
            {
                if (infoArgs.Length == 3)
                {
                    var name = infoArgs[0];
                    var age = int.Parse(infoArgs[1]);
                    var ID = long.Parse(infoArgs[2]);
                    Citizen citizen = new Citizen(name, age, ID);
                    identifiables.Add(citizen);
                }
                else if (infoArgs.Length == 2)
                {
                    var model = infoArgs[0];
                    var ID = long.Parse(infoArgs[1]);
                    Robot robot = new(model, ID);
                    identifiables.Add(robot);
                }
                infoArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            var lastDigits = int.Parse(Console.ReadLine());
            foreach (var item in identifiables)
            {
                if (item.ID.ToString().EndsWith(lastDigits.ToString()))
                {
                    Console.WriteLine(item.ID.ToString());
                }
            }
        }
    }
}