using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Point
    {
        private int x, y;

        public void Input()
        {
            Console.Write("Enter value for x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Enter value for y: ");
            y = int.Parse(Console.ReadLine());
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }

    sealed class Area
    {
        Point[] points;
        int n;
        int xmin, xmax, ymin, ymax;

        private static readonly Lazy<Area> lazy = new Lazy<Area>(() => new Area());
        public static Area GetInstance { get { return lazy.Value; } }

        public void AreaPoints(int n)
        {
            this.n = n;
            points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                points[i] = new Point();

                Console.WriteLine("Point of area");
                points[i].Input();
            }
        }

        public void Verification(Point p)
        {
            xmin = xmax = points[0].X;
            ymin = ymax = points[0].Y;

            for (int i = 1; i < n; i++)
            {
                if (xmin > points[i].X)
                    xmin = points[i].X;
                if (xmax < points[i].X)
                    xmax = points[i].X;
                if (ymin > points[i].Y)
                    ymin = points[i].Y;
                if (ymax < points[i].Y)
                    ymax = points[i].Y;
            }

            if(p.X >= xmin && p.X <= xmax && p.Y >= ymin && p.Y <= ymax)
                Console.WriteLine("Point " + p.X + ", " + p.Y + " is in the area!");
            else
                Console.WriteLine("Point " + p.X + ", " + p.Y + " is not in the area!");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int area_size;
            Console.Write("Enter number of points creating the area: ");
            area_size = int.Parse(Console.ReadLine());

            Area area = new Area();
            area.AreaPoints(area_size);

            int num_points;
            Console.Write("Enter number of points: ");
            num_points = int.Parse(Console.ReadLine());

            Point[] p = new Point[num_points];

            for (int i = 0; i < num_points; i++)
            {
                p[i] = new Point();
                p[i].Input();
            }

            foreach (var i in p)
            {
                area.Verification(i);
            }
        }
    }
}
