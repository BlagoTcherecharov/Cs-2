using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juices
{
    interface Juice
    {
        double Pourcentage();
        string Products();
    }

    class Apple : Juice
    {
        public double Pourcentage()
        {
            return 10.5;
        }

        public string Products()
        {
            return "apple, water and sugar";
        }
    }

    class Cherry : Juice
    {
        public double Pourcentage()
        {
            return 5;
        }

        public string Products()
        {
            return "cherry, water and sugar";
        }
    }

    class Orange : Juice
    {
        public double Pourcentage()
        {
            return 75.75;
        }

        public string Products()
        {
            return "orange, water and sugar";
        }
    }

    abstract class JuiceFactory
    {
        public abstract Juice GetJuice();
    }

    class AppleFactory : JuiceFactory
    {
        public override Juice GetJuice()
        {
            return new Apple();   
        }
    }

    class CherryFactory : JuiceFactory
    {
        public override Juice GetJuice()
        {
            return new Cherry();
        }
    }

    class OrangeFactory : JuiceFactory
    {
        public override Juice GetJuice()
        {
            return new Orange();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            JuiceFactory juice_factory = null;

            Console.Write("Enter juice name for more information: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "apple":
                    juice_factory = new AppleFactory();
                    break;
                case "cherry":
                    juice_factory = new CherryFactory();
                    break;
                case "orange":
                    juice_factory = new OrangeFactory();
                    break;
                default:
                    break;
            }

            Juice juice = juice_factory.GetJuice();

            Console.WriteLine("\n" + juice.GetType().Name + " is " + juice.Pourcentage() + "% fruit juice and contains " + juice.Products() + ".");
        }
    }
}
