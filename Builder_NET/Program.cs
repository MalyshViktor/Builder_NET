using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_NET
{
    interface IBuilder
    {
        void StartBuildProcess();
        void AddEngine();
        void AddTransmission();
        void AddWheels();
        void EndBuildingProcess();

        Product GetProduct();
    }

    class Product
    {
        LinkedList<string> parts;

        public Product()
        {
            parts = new LinkedList<string>();
        }
        public void Add(string component)
        {
            parts.AddLast(component);
        }
        public void Print()
        {
            Console.WriteLine("Printing components list:");
            foreach(string component in parts)
            {
                Console.WriteLine(component);
            }
        }
    }
    class CarBuilder : IBuilder
    {
        string carManufacturer;
        private Product product;

        public CarBuilder(string carName)
        {
            product = new Product();
            carManufacturer = carName;
        }
        public void StartBuildProcess()
        {
            product.Add(string.Format("Car named {0} created", carManufacturer));
        }
        public void AddEngine()
        {
            product.Add("Engine V8");
        }
        public void AddTransmission()
        {
            product.Add("Automatic transmission");
        }
        public void AddWheels()
        {
            product.Add("4 wheels");
        }
        public void EndBuildingProcess()
        {
            Console.WriteLine("Car construction finished.");
        }

        public Product GetProduct()
        {
            return product;
        }
    }

    class TruckBuilder : IBuilder
    {
        string truckManufacturer;
        private Product product;

        public TruckBuilder(string truckName)
        {
            product = new Product();
            truckManufacturer = truckName;
        }
        public void StartBuildProcess()
        {
            product.Add(string.Format("Truck named {0} created", truckManufacturer));
        }
        public void AddEngine()
        {
            product.Add("Engine V24");
        }
        public void AddTransmission()
        {
            product.Add("Manual 12 gears transmission");
        }
        public void AddWheels()
        {
            product.Add("10 wheels");
        }
        public void EndBuildingProcess()
        {
            Console.WriteLine("Truck construction finished.");
        }
        public Product GetProduct()
        {
            return product;
        }
    }

    class Director
    {
        IBuilder builder;
        public void Construct(IBuilder _builder)
        {
            this.builder = _builder;
            builder.StartBuildProcess();
            builder.AddEngine();
            builder.AddTransmission();
            builder.AddWheels();
            builder.EndBuildingProcess();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            IBuilder carBuilder = new CarBuilder("BMW X5");
            IBuilder truckBuilder = new TruckBuilder("Caterpillar");

            director.Construct(carBuilder);
            Product car = carBuilder.GetProduct();

            car.Print();
            
            director.Construct(truckBuilder);

            Console.WriteLine();

            Product truck = truckBuilder.GetProduct();
            truck.Print();

     
        }
    }
}
