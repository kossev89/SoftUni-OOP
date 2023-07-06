﻿
var number = int.Parse(Console.ReadLine());


try
{
    if (number < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    else
    {
        Console.WriteLine(Math.Sqrt(number));
    } 
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}