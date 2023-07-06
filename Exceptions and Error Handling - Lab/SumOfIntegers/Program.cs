namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            foreach (var item in input)
            {
                if (ProcessElement(item))
                {
                    sum += int.Parse(item);
                }
                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }



    static bool ProcessElement(string element)
        {
            int intElement = default;
     
            try
            {
                intElement = int.Parse(element);
                return true;
            }
            catch (Exception ex)
            {

                if (ex is OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                else if (ex is FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                return false;
            }
            
        }
    }
}