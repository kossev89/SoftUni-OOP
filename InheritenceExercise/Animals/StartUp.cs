using System;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (animalType != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string sex = animalInfo[2];

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, sex);
                            animals.Add(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, sex);
                            animals.Add(cat);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age, sex);
                            animals.Add(tomcat);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age, sex);
                            animals.Add(kitten);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, sex);
                            animals.Add(frog);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                animalType = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
                item.ProduceSound();
            }
        }
    }
}
