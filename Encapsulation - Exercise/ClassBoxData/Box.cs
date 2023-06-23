using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                height = value;
            }
        }


        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }


        public double Length
        {
            get { return length; }
            set
            {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Length cannot be zero or negative.");
                    }
                    length = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurface = 2 * Length * Height + 2 * Width * Height;
            return lateralSurface;
        }

        public double Volume()
        {
            double volume = Length * Width * Height;
            return volume;
        }

        public void Print()
        {
            Console.WriteLine($"Surface Area - {SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {Volume():f2}");
        }

    }
}
