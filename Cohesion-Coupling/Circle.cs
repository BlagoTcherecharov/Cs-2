using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Circle
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return radius * radius * Math.PI;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            int radius = int.Parse(Console.ReadLine());
            
            Circle c = new Circle(radius);

            Console.WriteLine("Area of circle is " + c.Area());
        }
    }
}
