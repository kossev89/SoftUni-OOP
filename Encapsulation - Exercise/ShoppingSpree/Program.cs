
namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new();
            List<Product> products = new();

            string[] personsInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in personsInfo)
            {
                string[] arg = item
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arg[0];
                decimal money = decimal.Parse(arg[1]);
                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            foreach (var item in productInfo)
            {
                string[] arg = item
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arg[0];
                decimal price = decimal.Parse(arg[1]);

                Product product = new Product(name, price);
                products.Add(product);
            }
            string[] commandInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commandInfo[0] != "END")
            {
                Person currentPerson = persons.FirstOrDefault(x => x.Name == commandInfo[0]);
                Product currentProduct = products.FirstOrDefault(x => x.Name == commandInfo[1]);
                currentPerson.Purchase(currentProduct);
                commandInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}