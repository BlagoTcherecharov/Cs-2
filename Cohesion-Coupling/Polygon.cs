using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Polygon
    {
        private double angle;

        public Polygon(double angle)
        {
            this.angle = angle;
        }

        public void Translation(Point p, Vector v)
        {
            p.x += v.Vx;
            p.y += v.Vy;

            Console.WriteLine("The point has been translated to {0}, {1}", p.x, p.y);
        }
        
        public void Rotation(Point p)
        {
            double x = p.x * Math.Cos(angle) - p.y * Math.Sin(angle);
            double y = p.x * Math.Sin(angle) + p.y * Math.Cos(angle);

            Console.WriteLine("The point has been rotated to {0}, {1}", x, y);
        }

        public void Area(Point[] p)
        {
            int n = p.Length;
            int area = 0;

            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;

                area += p[i].x * p[j].y;
                area -= p[j].x * p[i].y;
            }

            area = Math.Abs(area) / 2;

            Console.WriteLine("Area is " + area);
        }

        public void Perimeter(Point[] p)
        {
            int n = p.Length;
            double perimeter = 0;

            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;

                int dx = p[j].x = p[i].x;
                int dy = p[j].y - p[i].y;

                perimeter += Math.Sqrt(dx * dx + dy * dy);
            }

            Console.WriteLine("Perimeter is " + perimeter);
        }
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public void Input()
        {
            Console.Write("Enter value for x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Enter value for y: ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }

    class Vector
    {
        public int Vx { get; set; }
        public int Vy { get; set; }

        public void Input()
        {
            Console.Write("Enter value for Vx: ");
            Vx = int.Parse(Console.ReadLine());
            Console.Write("Enter value for Vy: ");
            Vy = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of sides of polygon: ");
            int sides = int.Parse(Console.ReadLine());
            double angle;

            Console.Write("Enter angle of rotation: ");
            angle = double.Parse(Console.ReadLine());

            Polygon[] polygon = new Polygon[sides];
            Point[] point = new Point[sides];

            Vector vector = new Vector();
            vector.Input();

            for (int i = 0; i < sides; i++)
            {
                point[i] = new Point();
                point[i].Input();
            }

            for (int i = 0; i < sides; i++)
            {
                polygon[i] = new Polygon(angle);
                polygon[i].Translation(point[i], vector);
            }

            for (int i = 0; i < sides; i++)
            {
                polygon[i].Rotation(point[i]);
            }

            polygon[0].Area(point);
            polygon[0].Perimeter(point);

            Console.ReadLine();
        }
    }
}
