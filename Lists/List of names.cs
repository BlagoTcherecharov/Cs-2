using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            Console.Write("Enter number of names: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                names.Add(name);
            }

            Console.WriteLine("\nNames starting with letter A:");

            for (int i = 0; i < n; i++)
            {
                if (names[i].StartsWith("A") || names[i].StartsWith("a"))
                {
                    Console.WriteLine(names[i]);
                }
            }

            Console.WriteLine("\nAll names:");

            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
        }
    }
}
