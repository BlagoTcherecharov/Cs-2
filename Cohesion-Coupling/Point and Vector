using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
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
            Console.WriteLine();
        }

        public void Translation(Vector v)
        {
            x += v.Vx;
            y += v.Vy;

            Console.WriteLine("The point has been translated to {0}, {1}", x, y);
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
            Vector v = new Vector();
            Point p = new Point();

            p.Input();
            v.Input();
            p.Translation(v);
        }
    }
}
