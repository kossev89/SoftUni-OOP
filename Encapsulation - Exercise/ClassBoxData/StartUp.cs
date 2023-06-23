﻿namespace ClassBoxData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                box.Print();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }
    }
}