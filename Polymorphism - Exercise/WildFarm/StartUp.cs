using WildFarm.Models;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] animalInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<Animal> animals = new List<Animal>();

            while (animalInfo[0] != "End")
            {
                string[] foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Animal currentAnimal = null;
                Food curretFood = null;

                switch (foodInfo[0])
                {
                    case "Vegetable":
                        Vegetable vegetable = new(int.Parse(foodInfo[1]));
                        curretFood = vegetable;
                        break;
                    case "Fruit":
                        Fruit fruit = new(int.Parse(foodInfo[1]));
                        curretFood = fruit;
                        break;
                    case "Meat":
                        Meat meat = new(int.Parse(foodInfo[1]));
                        curretFood = meat;
                        break;
                    case "Seeds":
                        Seeds seeds = new(int.Parse(foodInfo[1]));
                        curretFood = seeds;
                        break;
                }

                switch (animalInfo[0])
                {
                    case "Hen":
                        Hen hen = new(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        currentAnimal = hen;
                        break;
                    case "Owl":
                        Owl owl = new(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        currentAnimal = owl;
                        break;
                    case "Mouse":
                        Mouse mouse = new(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        currentAnimal = mouse;
                        break;
                    case "Cat":
                        Cat cat = new(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        currentAnimal = cat;
                        break;
                    case "Dog":
                        Dog dog = new(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        currentAnimal = dog;
                        break;
                    case "Tiger":
                        Tiger tiger = new(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        currentAnimal = tiger;
                        break;
                }
                currentAnimal.AskForFood();
                try
                {
                    currentAnimal.Eat(curretFood, curretFood.Quantity);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                animals.Add(currentAnimal);
                animalInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}