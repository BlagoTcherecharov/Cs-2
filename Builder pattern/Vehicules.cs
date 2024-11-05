using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    class Vehicule
    {
        private string vehiculeType;
        private List<string> parts = new List<string>();

        public Vehicule(string type)
        {
            vehiculeType = type;
        }

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine(vehiculeType);

            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }

    abstract class VehiculeBuilder
    {
        protected Vehicule vehicule;
        public Vehicule Vehicule
        {
            get {return vehicule;}
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
        public abstract void BuildSeats();
    }

    class CarBuilder : VehiculeBuilder
    {
        public CarBuilder()
        {
            vehicule = new Vehicule("Car");
        }

        public override void BuildFrame()
        {
            vehicule.Add("Car Frame");
        }

        public override void BuildEngine()
        {
            vehicule.Add("Engine 2500 cc");
        }

        public override void BuildWheels()
        {
            vehicule.Add("Wheels 4");
        }

        public override void BuildDoors()
        {
            vehicule.Add("Doors 4");
        }

        public override void BuildSeats()
        {
            vehicule.Add("Seats 5");
        }
    }

    class MotorCycleBuilder : VehiculeBuilder
    {
        public MotorCycleBuilder()
        {
            vehicule = new Vehicule("Motorcycle");
        }

        public override void BuildFrame()
        {
            vehicule.Add("MotorCycle Frame");
        }

        public override void BuildEngine()
        {
            vehicule.Add("Engine 500 cc");
        }

        public override void BuildWheels()
        {
            vehicule.Add("Wheels 2");
        }

        public override void BuildDoors()
        {
            vehicule.Add("Doors 0");
        }

        public override void BuildSeats()
        {
            vehicule.Add("Seats 2");
        }
    }

    class BusBuilder : VehiculeBuilder
    {
        public BusBuilder()
        {
            vehicule = new Vehicule("Bus");
        }

        public override void BuildFrame()
        {
            vehicule.Add("Bus Frame");
        }

        public override void BuildEngine()
        {
            vehicule.Add("Engine 4000 cc");
        }

        public override void BuildWheels()
        {
            vehicule.Add("Wheels 8");
        }

        public override void BuildDoors()
        {
            vehicule.Add("Doors 2");
        }

        public override void BuildSeats()
        {
            vehicule.Add("Seats 30");
        }
    }

    class Director
    {
        public void Construct(VehiculeBuilder vehiculeBuilder)
        {
            vehiculeBuilder.BuildFrame();
            vehiculeBuilder.BuildEngine();
            vehiculeBuilder.BuildWheels();
            vehiculeBuilder.BuildDoors();
            vehiculeBuilder.BuildSeats();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VehiculeBuilder[] vehiculeBuilders = new VehiculeBuilder[3];
            Director producer = new Director();

            vehiculeBuilders[0] = new CarBuilder();
            producer.Construct(vehiculeBuilders[0]);
            vehiculeBuilders[0].Vehicule.Show();
            Console.WriteLine();
            vehiculeBuilders[1] = new MotorCycleBuilder();
            producer.Construct(vehiculeBuilders[1]);
            vehiculeBuilders[1].Vehicule.Show();
            Console.WriteLine();
            vehiculeBuilders[2] = new BusBuilder();
            producer.Construct(vehiculeBuilders[2]);
            vehiculeBuilders[2].Vehicule.Show();
        }
    }
}
