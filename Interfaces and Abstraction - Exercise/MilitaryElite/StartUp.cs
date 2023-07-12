using MilitaryElite.Interfaces;
using MilitaryElite.Models;

string[] inputLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
List<Soldier> army = new();

while (inputLine[0] != "End")
{
    string type = inputLine[0];
    int id = int.Parse(inputLine[1]);
    string firstName = inputLine[2];
    string lastName = inputLine[3];
    decimal salary = decimal.Parse(inputLine[4]);
    int codeNumber = 0;
    int.TryParse(inputLine[4], out codeNumber);
    string corps = default;
    if (inputLine.Length > 5)
    {
        corps = inputLine[5];
    }

    switch (type)
    {
        case "Private":
            Private @private = new(id, firstName, lastName, salary);
            army.Add(@private);
            break;
        case "LieutenantGeneral":
            LieutenantGeneral lieutenant = new(id, firstName, lastName, salary);
            for (int i = 5; i < inputLine.Length; i++)
            {
                int iD = int.Parse(inputLine[i]);
                Private currentPrivate = army.FirstOrDefault(x => x.Id == iD) as Private;
                lieutenant.AddPrivate(currentPrivate);
            }
            army.Add(lieutenant);
            break;
        case "Engineer":
            try
            {
                Engineer engineer = new(id, firstName, lastName, salary, corps);
                for (int i = 6; i < inputLine.Length; i += 2)
                {
                    string partName = inputLine[i];
                    int hoursWorked = int.Parse(inputLine[i + 1]);
                    Repair repair = new(partName, hoursWorked);
                    engineer.AddRepair(repair);
                }
                army.Add(engineer);
            }
            catch (Exception)
            {

                continue;
            }
            break;
        case "Commando":
            try
            {
                Commando commando = new(id, firstName, lastName, salary, corps);
                for (int i = 6; i < inputLine.Length; i += 2)
                {
                    string codeName = inputLine[i];
                    string state = inputLine[i + 1];
                    try
                    {
                        Mission mission = new(codeName, state);
                        commando.AddMission(mission);
                    }
                    catch (Exception)
                    {

                        continue;
                    };
                }
                army.Add(commando);
            }
            catch (Exception)
            {

                continue;
            }
            break;
        case "Spy":
            Spy spy = new(id, firstName, lastName, codeNumber);
            army.Add(spy);
            break;
    }
    inputLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
foreach (var item in army)
{
    Console.WriteLine(item.ToString());
}









//static Private CreateInstance(int id, string firstName, string lastName, decimal salary)
//{
//    Private @private = new(id, firstName, lastName, salary);
//    return @private;
//}
