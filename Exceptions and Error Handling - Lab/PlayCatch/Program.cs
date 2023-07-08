using System.Runtime.CompilerServices;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionsCounter = 0;

            while (exceptionsCounter < 3)
            {
                string[] commandArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commandArg[0])
                {
                    case "Replace":
                        try
                        {
                            input[int.Parse(commandArg[1])] = int.Parse(commandArg[2]);
                        }
                        catch (Exception ex)
                        {
                            if (ex is IndexOutOfRangeException)
                            {
                                Console.WriteLine("The index does not exist!");
                                exceptionsCounter++;
                            }
                            else if (ex is FormatException)
                            {
                                Console.WriteLine("The variable is not in the correct format!");
                                exceptionsCounter++;
                            }
                        }
                        break;
                    case "Print":
                        int startIndex = default;
                        int endIndex = default;

                        try
                        {
                            if (int.TryParse(commandArg[1], out startIndex)
                            && int.TryParse(commandArg[2], out endIndex)
                            )
                            {
                                if (startIndex >= 0
                                && startIndex < input.Length
                                && endIndex >= 0
                                && endIndex < input.Length
                                )
                                {
                                    var printRange = input.Skip(int.Parse(commandArg[1]))
                                        .Take(endIndex - startIndex + 1).ToArray();
                                    Console.WriteLine(String.Join(", ", printRange));
                                }
                                else
                                {
                                    throw new IndexOutOfRangeException();
                                }
                            }
                            else
                            {
                                throw new FormatException();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IndexOutOfRangeException)
                            {
                                Console.WriteLine("The index does not exist!");
                                exceptionsCounter++;
                            }
                            else if (ex is FormatException)
                            {
                                Console.WriteLine("The variable is not in the correct format!");
                                exceptionsCounter++;
                            }
                        }
                        break;
                    case "Show":
                        try
                        {
                            int indexToPrint = int.Parse(commandArg[1]);
                            Console.WriteLine(input[indexToPrint]);
                        }
                        catch (Exception ex)
                        {
                            if (ex is IndexOutOfRangeException)
                            {
                                Console.WriteLine("The index does not exist!");
                                exceptionsCounter++;
                            }
                            else if (ex is FormatException)
                            {
                                Console.WriteLine("The variable is not in the correct format!");
                                exceptionsCounter++;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", input));
        }
    }
}