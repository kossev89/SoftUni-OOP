using BorderControl.Models;
using FoodShortage.Models;
using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<IBuyer> buyers = new();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 4)
                {
                    if (!ContainsName(buyers, info[0]))
                    {
                        Citizen citizen = new(info[0], int.Parse(info[1]), long.Parse(info[2]), info[3]);
                        buyers.Add(citizen);
                    }         
                }
                if (info.Length == 3)
                {
                    if (!ContainsName(buyers, info[0]))
                    {
                        Rebel rebel = new(info[0], int.Parse(info[1]), info[2]);
                        buyers.Add(rebel);
                    }            
                }
            }
            string name = Console.ReadLine();
            while (name != "End")
            {
                if (buyers.Where(n => n.Name == name).Any())
                {
                    var currentBuyer = buyers.FirstOrDefault(n => n.Name == name);
                    currentBuyer.BuyFood();
                }
                name = Console.ReadLine();
            }
            int totalFoodBought = 0;
            foreach (var buyer in buyers)
            {
                totalFoodBought += buyer.Food;
            }
            Console.WriteLine(totalFoodBought);

        }
        public static bool ContainsName(HashSet<IBuyer> buyers, string name)
        {
            if (buyers.Where(n => n.Name == name).Any())
            {
                return true;
            }
            return false;
        }
    }


}