using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    interface IAnimals
    {
        string GetLivingPlace();
        string GetLatinName();
        string GetEatingRegime();
    }
    interface IElephant : IAnimals
    {
        int GetWeight();
        int GetHeight();
    }
    interface ILion : IAnimals
    {
        string GetFeatures();
        void CanMeet(IElephant elephant);
    }

    class AfricanElephant : IElephant
    {
        public int GetWeight()
        {
            return 7500;
        }
        public int GetHeight()
        {
            return 4;
        }
        public string GetLivingPlace()
        {
            return "wetlands";
        }
        public string GetLatinName()
        {
            return "Loxodonta africana";
        }
        public string GetEatingRegime()
        {
            return "herbivore";
        }
    }

    class IndianElephant : IElephant
    {
        public int GetWeight()
        {
            return 6000;
        }
        public int GetHeight()
        {
            return 3;
        }
        public string GetLivingPlace()
        {
            return "forests";
        }
        public string GetLatinName()
        {
            return "Elephas maximus indicus";
        }
        public string GetEatingRegime()
        {
            return "herbivore";
        }
    }

    class AfricanLion : ILion
    {
        public string GetFeatures()
        {
            return " has a big mane";
        }
        public void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " can meet " + elephant.GetType().Name);
        }
        public string GetLivingPlace()
        {
            return "savanna";
        }
        public string GetLatinName()
        {
            return "Panthera leo";
        }
        public string GetEatingRegime()
        {
            return "carnivore";
        }
    }

    class AsiaticLion : ILion
    {
        public string GetFeatures()
        {
            return " has a small mane";
        }
        public void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " can meet " + elephant.GetType().Name);
        }
        public string GetLivingPlace()
        {
            return "forest";
        }
        public string GetLatinName()
        {
            return "Panthera leo persica";
        }
        public string GetEatingRegime()
        {
            return "carnivore";
        }
    }

    interface IContinentalFactory
    {
        ILion CreateLion();
        IElephant CreateElephant();
    }

    class AfricanFactory : IContinentalFactory
    {
        public ILion CreateLion()
        {
            return new AfricanLion();
        }
        public IElephant CreateElephant()
        {
            return new AfricanElephant();
        }
    }

    class AsiaticFactory : IContinentalFactory
    {
        public ILion CreateLion()
        {
            return new AsiaticLion();
        }
        public IElephant CreateElephant()
        {
            return new IndianElephant();
        }
    }

    class Client
    {
        private ILion lion;
        private IElephant elephant;

        public Client(IContinentalFactory factory)
        {
            lion = factory.CreateLion();
            elephant = factory.CreateElephant();
        }

        public void Run()
        {
            Console.WriteLine(elephant.GetType().Name + " weights " + elephant.GetWeight() + "kg");
            Console.WriteLine(elephant.GetType().Name + " is " + elephant.GetHeight() + "m tall");
            Console.WriteLine(elephant.GetType().Name + " lives in the " + elephant.GetLivingPlace());
            Console.WriteLine(elephant.GetType().Name + " name in latin is " + elephant.GetLatinName());
            Console.WriteLine(elephant.GetType().Name + " regime is " + elephant.GetEatingRegime() + "\n");

            Console.WriteLine(lion.GetType().Name + lion.GetFeatures());
            lion.CanMeet(elephant);
            Console.WriteLine(lion.GetType().Name + " lives in the " + lion.GetLivingPlace());
            Console.WriteLine(lion.GetType().Name + " name in latin is " + lion.GetLatinName());
            Console.WriteLine(lion.GetType().Name + " regime is " + lion.GetEatingRegime() + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IContinentalFactory factory1 = new AfricanFactory();
            Client client1 = new Client(factory1);
            client1.Run();

            IContinentalFactory factory2 = new AsiaticFactory();
            Client client2 = new Client(factory1);
            client1.Run();
        }
    }
}
