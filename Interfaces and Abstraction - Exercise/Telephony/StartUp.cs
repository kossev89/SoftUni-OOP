using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new();
            StationaryPhone stationary = new();

            foreach (var number in numbers)
            {
                bool isValid = true;
                foreach (var c in number)
                {
                    if (!Char.IsDigit(c))
                    {
                        Console.WriteLine("Invalid number!");
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    if (number.Length == 10)
                    {
                        smartphone.Calling(number);
                    }
                    else
                    {
                        stationary.Calling(number);
                    }
                }
                else
                {
                    continue;
                }
            }

            foreach (var site in sites)
            {
                bool isValid = true;
                foreach (var c in site)
                {
                    if (Char.IsDigit(c))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    smartphone.Browsing(site);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}