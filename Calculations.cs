using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    abstract class Shape
    {
        protected int b, h;

        protected Shape(int b, int h)
        {
            this.b = b;
            this.h = h;
        }

        protected Shape(int b)
        {
            this.b = b;
        }

        abstract public double CalculateArea();
    }

    class Rectangle : Shape
    {
        public Rectangle(int b, int h) : base(b, h) { }

        public override double CalculateArea()
        {
            return b * h;
        }

    }

    class Triangle : Shape
    {
        public Triangle(int b, int h) : base(b, h) { }

        public override double CalculateArea()
        {
            return b * h / 2;
        }
    }

    class Circle : Shape
    {
        public Circle(int b) : base(b) { }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(b, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { new Rectangle(2, 3), new Rectangle(3, 4), new Rectangle(1, 2), new Triangle(3, 4), new Triangle(5, 6), new Circle(4), new Circle(5) };

            double[] result = new double[7];

            for (int i = 0; i < shapes.Length; i++)
            {
                result[i] = shapes[i].CalculateArea();
            }

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}
