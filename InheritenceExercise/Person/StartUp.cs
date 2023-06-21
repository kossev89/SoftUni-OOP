using System;
using System.Runtime.ConstrainedExecution;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            if (age > 15)
            {
                Person person = new Person(age, name);
                Console.WriteLine(person.ToString());
            }
            else if (age >= 0 && age <= 15)
            {
                Child child = new Child(age, name);
                Console.WriteLine(child.ToString());
            }
        }
    }
}