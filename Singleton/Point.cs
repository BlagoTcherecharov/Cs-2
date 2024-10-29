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

            for (int i = 0; i < n; i++)
            {
                points = new Point[n];

                Console.WriteLine("Point of area");
                points[i].Input();
            }
        }

        public void Verification()
        {
            xmin = xmax = points[0].X;
            ymin = ymax = points[0].Y;

            for (int i = 1; i < n; i++)
            {
                if (xmin > points[i].X)
                    xmin = points[i].X;
                if (xmax < points[i].X)
                    xmax = points[i].X;
                if (xmin > points[i].Y)
                    xmin = points[i].X;
                if (xmax < points[i].Y)
                    xmax = points[i].X;
            }

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
        }
    }
}
