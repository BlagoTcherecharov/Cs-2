using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandwich
{
    class Sandwich
    {
        private string sandwichType;
        private List<string> ingredients = new List<string>();

        public Sandwich(string type)
        {
            sandwichType = type;
        }

        public void Add(string ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void Show()
        {
            Console.WriteLine(sandwichType);

            foreach (string i in ingredients)
                Console.WriteLine(i);
        }
    }

    abstract class SandwichBuilder
    {
        protected Sandwich sandwich;
        public Sandwich Sandwich
        {
            get {return sandwich;}
        }

        protected bool Check(string input)
        {
            if (input == "y")
                return true;
            return false;
        }

        public void BuildBread()
        {
            int choice = 0;
            while(choice != 1 && choice != 2)
            {
                Console.WriteLine("Choose type of bread: ");
                Console.WriteLine("1. White bread");
                Console.WriteLine("2. Brown bread");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: Sandwich.Add("White bread"); break;
                    case 2: Sandwich.Add("Brown bread"); break;
                    default: Console.WriteLine("No such choice!"); break;
                }
            }
        }
        public abstract void BuildSalad();
        public abstract void BuildPrice();
    }

    class MeatSandwich : SandwichBuilder
    {
        public MeatSandwich()
        {
            sandwich = new Sandwich("Meat sandwich");
        }

        public override void BuildSalad()
        {
            bool onion, cucumber, tomato;
            string read;

            Console.Write("Do you want onion in sandwich(y/n): ");
            read = Console.ReadLine();
            onion = Check(read);
            if (onion)
                sandwich.Add("Salad onion");
            Console.Write("Do you want cucumber in sandwich(y/n): ");
            read = Console.ReadLine();
            cucumber = Check(read);
            if (cucumber)
                sandwich.Add("Salad cucumber");
            Console.Write("Do you want tomato in sandwich(y/n): ");
            read = Console.ReadLine();
            tomato = Check(read);
            if (tomato)
                sandwich.Add("Salad tomato");
        }
        public override void BuildPrice()
        {
            sandwich.Add("4.50$");
        }
    }

    class CheeseSandwich : SandwichBuilder
    {
        public CheeseSandwich()
        {
            sandwich = new Sandwich("Cheese sandwich");
        }

        public override void BuildSalad()
        {
            bool cucumber, tomato, lettuce;
            string read;
            
            Console.Write("Do you want cucumber in sandwich(y/n): ");
            read = Console.ReadLine();
            cucumber = Check(read);
            if (cucumber)
                sandwich.Add("Salad cucumber");
            Console.Write("Do you want tomato in sandwich(y/n): ");
            read = Console.ReadLine();
            tomato = Check(read);
            if (tomato)
                sandwich.Add("Salad tomato");
            Console.Write("Do you want lettuce in sandwich(y/n): ");
            read = Console.ReadLine();
            lettuce = Check(read);
            if (lettuce)
                sandwich.Add("Salad lettuce");
        }
        public override void BuildPrice()
        {
            sandwich.Add("4.00$");
        }
    }

    class Director
    {
        public void Construct(SandwichBuilder sandwichBuilder)
        {
            sandwichBuilder.BuildBread();
            sandwichBuilder.BuildSalad();
            sandwichBuilder.BuildPrice();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of sandwiches: ");
            int num_sandwiches = int.Parse(Console.ReadLine());

            SandwichBuilder[] sandwichBuilders = new SandwichBuilder[num_sandwiches];
            Director producer = new Director();

            for (int i = 0; i < num_sandwiches; i++)
            {
                Console.WriteLine("Type of sandwich: ");
                Console.Write("Meat sandwich or Cheese Sandwich (meat/cheese): ");
                string choice = Console.ReadLine();

                if(choice == "meat")
                    sandwichBuilders[i] = new MeatSandwich();
                else if(choice == "cheese")
                    sandwichBuilders[i] = new CheeseSandwich();

                producer.Construct(sandwichBuilders[i]);
                sandwichBuilders[i].Sandwich.Show();
            }
        }
    }
}
