using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesFactoryMethod
{
    abstract class Shapes
    {
        protected double side1, side2;
        protected double area, perimeter;
        protected string figureType;
        public abstract string FigureType { get; }
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public Shapes(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public abstract void CalculateArea();
        public abstract void CalculatePerimeter();
    }

    class Circle : Shapes
    {
        public Circle(double side1, double side2) : base(side1, side2)
        {
            figureType = "Circle";
        }

        public override string FigureType { get { return figureType; } }

        public override void CalculateArea()
        {
            area = Math.PI * side1 * side1;
        }

        public override double Area { get { return area; } }

        public override void CalculatePerimeter()
        {
            perimeter = 2 * Math.PI * side1;
        }

        public override double Perimeter { get { return perimeter; } }
    }

    class Rectangle : Shapes
    {
        public Rectangle(double side1, double side2) : base(side1, side2)
        {
            figureType = "Rectangle";
        }

        public override string FigureType { get { return figureType; } }

        public override void CalculateArea()
        {
            area = side1 * side2;
        }

        public override double Area { get { return area; } }

        public override void CalculatePerimeter()
        {
            perimeter = 2 * (side1 + side2);
        }

        public override double Perimeter { get { return perimeter; } }
    }

    class Square : Shapes
    {
        public Square(double side1, double side2) : base(side1, side2)
        {
            figureType = "Square";
        }

        public override string FigureType { get { return figureType; } }

        public override void CalculateArea()
        {
            area = side1 * side1;
        }

        public override double Area { get { return area; } }

        public override void CalculatePerimeter()
        {
            perimeter = 4 * side1;
        }

        public override double Perimeter { get { return perimeter; } }
    }

    abstract class ShapeFactory
    {
        public abstract Shapes GetShapes();
    }

    class CircleFactory : ShapeFactory
    {
        private double side1, side2;

        public CircleFactory(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public override Shapes GetShapes()
        {
            return new Circle(side1, side2);
        }
    }

    class RectangleFactory : ShapeFactory
    {
        private double side1, side2;

        public RectangleFactory(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public override Shapes GetShapes()
        {
            return new Rectangle(side1, side2);
        }
    }

    class SquareFactory : ShapeFactory
    {
        private double side1, side2;

        public SquareFactory(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public override Shapes GetShapes()
        {
            return new Square(side1, side2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory[] shape_factory = new ShapeFactory[3];
            Shapes[] shapes = new Shapes[3];

            double side1 = 0, side2 = 0;

            for (int i = 0; i < shape_factory.Length; i++)
            {
                Console.Write("Enter shape: ");
                string shape = Console.ReadLine();

                switch (shape.ToLower())
                {
                    case "circle":
                        Console.Write("Enter radius of circle: ");
                        side1 = Double.Parse(Console.ReadLine());
                        shape_factory[i] = new CircleFactory(side1, side2);
                        break;
                    case "rectangle":
                        Console.Write("Enter base of rectangle: ");
                        side1 = Double.Parse(Console.ReadLine());
                        Console.Write("Enter height of rectangle: ");
                        side2 = Double.Parse(Console.ReadLine());
                        shape_factory[i] = new RectangleFactory(side1, side2);
                        break;
                    case "square":
                        Console.Write("Enter side of square: ");
                        side1 = Double.Parse(Console.ReadLine());
                        shape_factory[i] = new SquareFactory(side1, side2);
                        break;
                    default:
                        i--;
                        break;
                }
            }

            for (int i = 0; i < shape_factory.Length; i++)
            {
                shapes[i] = shape_factory[i].GetShapes();
                shapes[i].CalculateArea();
                shapes[i].CalculatePerimeter();

                Console.WriteLine("\nShape is a {0}, has a perimeter of {1} and an area of {2}", shapes[i].FigureType, shapes[i].Perimeter, shapes[i].Area);
            }

        }
    }
}
