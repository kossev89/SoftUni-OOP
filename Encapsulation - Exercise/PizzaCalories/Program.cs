namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = string.Empty;
            try
            {
                pizzaName = pizzaInfo[1];
            }
            catch (Exception pizzaEx)
            {

               
            }
            
            try
            {
                Pizza pizza = new(pizzaName);
                string[] inputInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                while (inputInfo[0] != "END")
                {
                    switch (inputInfo[0])
                    {
                        case "Dough":
                            string flourType = inputInfo[1];
                            string bakingTechnique = inputInfo[2];
                            int weight = int.Parse(inputInfo[3]);
                            try
                            {
                                Dough dough = new Dough(flourType, bakingTechnique, weight);
                                pizza.Dough = dough;
                                
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                                return;
                            }
                            break;
                        case "Topping":
                            string type = inputInfo[1];
                            int weightTopping = int.Parse(inputInfo[2]);
                            try
                            {
                                Topping topping = new(type, weightTopping);
                                try
                                {
                                    pizza.AddTopping(topping);
                                }
                                catch (Exception top)
                                {

                                    Console.WriteLine(top.Message);
                                    return;
                                }
                            }
                            catch (Exception top)
                            {
                                Console.WriteLine(top.Message);
                                return;
                            }
                            break;
                    }
                    inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception pizzaEx)
            {

                Console.WriteLine(pizzaEx.Message);
            }
        }
    }
}