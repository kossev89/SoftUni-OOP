using Raiding.Models;
using System.ComponentModel;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    switch (heroType)
                    {
                        case "Druid":
                            Druid druid = new(heroName);
                            raidGroup.Add(druid);
                            break;
                        case "Paladin":
                            Paladin paladin = new(heroName);
                            raidGroup.Add(paladin);
                            break;
                        case "Rogue":
                            Rogue rogue = new(heroName);
                            raidGroup.Add(rogue);
                            break;
                        case "Warrior":
                            Warrior warrior = new(heroName);
                            raidGroup.Add(warrior);
                            break;
                        default:
                            throw new ArgumentException("Invalid hero!");
                            
                    }
                }
                catch (Exception ex)
                {
                    i--;
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            if (bossPower > 0)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}