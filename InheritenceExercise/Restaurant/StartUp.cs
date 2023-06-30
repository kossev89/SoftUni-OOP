using System.Net.Http.Headers;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Fish fish = new Fish("karakuda", 2.5m);
            System.Console.WriteLine(fish.Grams);
            Cake cake = new Cake("torta");
            System.Console.WriteLine($"{cake.Name} {cake.Price} {cake.Grams} {cake.Calories}");
        }
    }
}