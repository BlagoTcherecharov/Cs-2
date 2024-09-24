using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class City
    {
        protected string city_name;
        protected int postal_code;

        public City(string city_name, int postal_code)
        {
            this.city_name = city_name;
            this.postal_code = postal_code;
        }

        public string City_name { get { return city_name; } }
        public int Postal_code { get { return postal_code; } }
    }

    class Program
    {
        void add(List<City> cities)
        {
            Console.Write("Enter city to add: ");
            string city_name = Console.ReadLine();
            Console.Write("Enter postal code of the city: ");
            int postal_code = int.Parse(Console.ReadLine());

            cities.Add(new City(city_name, postal_code));
        }

        void remove(List<City> cities)
        {
            Console.Write("Enter city to remove: ");
            string city_name = Console.ReadLine();

            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].City_name == city_name)
                    cities.Remove(cities[i]);
            }
        }

        void addPosition(List<City> cities)
        {
            Console.Write("Enter position where to add: ");
            int position = int.Parse(Console.ReadLine());

            Console.Write("Enter city to add: ");
            string city_name = Console.ReadLine();
            Console.Write("Enter postal code of the city: ");
            int postal_code = int.Parse(Console.ReadLine());

            cities.Insert(position, new City(city_name, postal_code));
        }

        void print(List<City> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine(cities[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            bool stop = false;

            while(stop == false)
            {
                Console.WriteLine("1. Add city");
                Console.WriteLine("2. Remove city");
                Console.WriteLine("3. Add city in a position");
                Console.WriteLine("4. Print cities");
                Console.WriteLine("5. Finish");

                Console.Write("Enter option: ");
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: 
                }

            }

        }
    }
}
