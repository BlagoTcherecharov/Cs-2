using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    interface ICalculations
    {
        double GetArea();
        double GetPerimeter();
    }

    interface ICircle : ICalculations
    {
        double GetRadius();
    }

    interface IRectangle : ICalculations
    {
        double GetDiagonal();
    }

    interface ISquare : ICalculations
    {
        double GetDiagonal();
    }

    class BlueCircle : ICircle
    {
        private int radius = 5;

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetRadius()
        {
            return radius;
        }
    }

    class RedCircle : ICircle
    {
        private int radius = 3;

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetRadius()
        {
            return radius;
        }
    }

    class BlueRectangle : IRectangle
    {
        private int h = 5;
        private int b = 3;

        public double GetArea()
        {
            return b * h;
        }

        public double GetPerimeter()
        {
            return 2 * (b + h);
        }

        public double GetDiagonal()
        {
            return Math.Sqrt(Math.Pow(b, 2) + Math.Pow(h, 2));
        }
    }

    class RedRectangle : IRectangle
    {
        private int h = 3;
        private int b = 2;

        public double GetArea()
        {
            return b * h;
        }

        public double GetPerimeter()
        {
            return 2 * (b + h);
        }

        public double GetDiagonal()
        {
            return Math.Sqrt(Math.Pow(b, 2) + Math.Pow(h, 2));
        }
    }
    
    class BlueSquare : ISquare
    {
        private int side = 4;

        public double GetArea()
        {
            return side * side;
        }

        public double GetPerimeter()
        {
            return 4 * side;
        }

        public double GetDiagonal()
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }
    }

    class RedSquare : ISquare
    {
        private int side = 2;

        public double GetArea()
        {
            return side * side;
        }

        public double GetPerimeter()
        {
            return 4 * side;
        }

        public double GetDiagonal()
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }
    }


    interface IShapesFactory
    {
        ICircle CreateCircle();
        IRectangle CreateRectangle();
        ISquare CreateSquare();
    }

    class BlueFactory : IShapesFactory
    {
        public ICircle CreateCircle()
        {
            return new BlueCircle();
        }

        public IRectangle CreateRectangle()
        {
            return new BlueRectangle();
        }

        public ISquare CreateSquare()
        {
            return new BlueSquare();
        }
    }

    class RedFactory : IShapesFactory
    {
        public ICircle CreateCircle()
        {
            return new RedCircle();
        }

        public IRectangle CreateRectangle()
        {
            return new RedRectangle();
        }

        public ISquare CreateSquare()
        {
            return new RedSquare();
        }
    }

    class Client
    {
        private ICircle circle;
        private IRectangle rectangle;
        private ISquare square;

        public Client(IShapesFactory factory)
        {
            circle = factory.CreateCircle();
            rectangle = factory.CreateRectangle();
            square = factory.CreateSquare();
        }

        public void Run()
        {
            Console.WriteLine(circle.GetType().Name + " perimeter is " + circle.GetPerimeter() + "cm");
            Console.WriteLine(circle.GetType().Name + " area is " + circle.GetArea() + "cm");
            Console.WriteLine(circle.GetType().Name + " radius is " + circle.GetRadius() + "cm\n");

            Console.WriteLine(rectangle.GetType().Name + " perimeter is " + rectangle.GetPerimeter() + "cm");
            Console.WriteLine(rectangle.GetType().Name + " area is " + rectangle.GetArea() + "cm");
            Console.WriteLine(rectangle.GetType().Name + " diagonal is " + rectangle.GetDiagonal() + "cm\n");

            Console.WriteLine(square.GetType().Name + " perimeter is " + square.GetPerimeter() + "cm");
            Console.WriteLine(square.GetType().Name + " area is " + square.GetArea() + "cm");
            Console.WriteLine(square.GetType().Name + " diagonal is " + square.GetDiagonal() + "cm\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IShapesFactory factory1 = new BlueFactory();
            Client client1 = new Client(factory1);
            client1.Run();

            IShapesFactory factory2 = new RedFactory();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }
}
