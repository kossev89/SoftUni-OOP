namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (inputInfo[0] != "END")
            {
                switch (inputInfo[0])
                {
                    case "Dough":
                        string flourType = inputInfo[1].ToLower();
                        string bakingTechnique = inputInfo[2].ToLower();
                        int weight = int.Parse(inputInfo[3]);
                        try
                        {
                            Dough dough = new Dough(flourType, bakingTechnique, weight);
                            dough.CalculateCalories();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
                inputInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);





            }
        }
    }
}