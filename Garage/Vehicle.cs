using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{     /// <summary>
      /// Fordon implementeras som abstract klassen Vehicle och dess ärvda klasser.
      /// Vehicle innehåler egenskaper som finns i samtliga fordonstyper. samtidgt subklasser implementerar
      /// en egenskap.
      /// </summary>
    public abstract class Vehicle
    {

        private string _vehicle;
        private string _registernumber;
        private string _color;
        private int _numberOfWheels;


        public Vehicle(string vehicle)
        {
            _vehicle = vehicle;
        }

        public Vehicle(string vehicle,string registernumber,string color, int numberOfWheels)
        {
            _vehicle = vehicle;
            _registernumber = registernumber;
            _color = color;
            _numberOfWheels = numberOfWheels;

        }

        public string Vehicle1
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        public string RegisterNumber
        {
            get { return _registernumber; }
            set { _registernumber = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }

        }

        public int NumberOfWheels
        {
            get { return _numberOfWheels; }
            set { _numberOfWheels = value; }
        }

        

        // Skapar ett metod för att overrida sublkasser för att returnera alla egenskaper(properties) som Vehicle har.
        public virtual string Stats()
        {
            return $" Registernumber:{RegisterNumber}\nColor: {Color}\n Number of Wheels:{NumberOfWheels}";
                   
        }

         

    }

    class Airplane : Vehicle
    {

        private int _numberOfEngines;


        public Airplane(string airplane, string registernumber, string color, int numberOfWheels, int numberOfEngines)
            : base(airplane, registernumber, color, numberOfWheels)
        {
            //_vehicle = airplane;
             Vehicle1 = airplane;
            _numberOfEngines = numberOfEngines;
        }

        //public Airplane(string airplane)
        //    : base(airplane)
        //{
        //    Vehicle1 = airplane;
        //}
        public int NumberOfEngines { get; set; }
        public string Vehicle { get; set; }

        public override string Stats()
        {
            Console.WriteLine($"Vehicle:{Vehicle1})\nNumber of Engines:{NumberOfEngines}");
            return base.Stats() + $"{NumberOfEngines}";
        }
    }
    class Motorcycle : Vehicle
    {
        private int _cylinderVolume;

        public Motorcycle(string motorcycle, string registernumber, string color, int numberOfWheels, int cylinderVolume)
            : base(motorcycle, registernumber, color, numberOfWheels)
        {
             Vehicle1 = motorcycle;
            _cylinderVolume = cylinderVolume;
        }
        //public Motorcycle(string motorcycle)
        //    : base(motorcycle)
        //{
        //    Vehicle1 = motorcycle;
        //}

        public int CylinderVolume { get; set; }
        public string Vehicle { get; set; }
        public override string Stats()
        {
            Console.WriteLine($"Vehicle :{Vehicle1}\nCylinder Volume:{CylinderVolume}");
            return base.Stats() + $"{CylinderVolume}";
        }
    }
    class Car : Vehicle
    {
        private string _fuelType;
        private string _brand;

        public Car(string car, string regnumber, string color, int numberofwheels, string fuelType, string Brand)
            : base(car, regnumber, color, numberofwheels)
        {
            Vehicle1 = car;
            _fuelType = fuelType;
            _brand = Brand;
        }

        //public Car(string car)
        //    : base(car)
        //{
        //    Vehicle1 = car;
        //}
        public string FuelType
        {
            get { return _fuelType; }
            set { _fuelType = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Vehicle { get; set; }
        public override string Stats()
        {
            Console.WriteLine($"Vehicle:{Vehicle1}\nBrand:{Brand}\n Fuel Type:{FuelType}");
            return base.Stats() + $"{FuelType}";
        }

    }
    class Bus : Vehicle
    {
        private int _numberOfSeats;

        public Bus(string bus, string registernumber, string color, int numberOfWheels, int numberOfSeats, string fuelType)
            : base(bus, registernumber, color, numberOfWheels)
        {
            Vehicle1 = bus;
            _numberOfSeats = numberOfSeats;
        }
        //public Bus(string bus)
        //    : base(bus)
        //{
        //    Vehicle1 = bus;
        //}
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set { _numberOfSeats = value; }
        }

        public string Vehicle { get; set; }
        public override string Stats()
        {
            Console.WriteLine($"Vehicle:{Vehicle1}\nNumber of seats:{NumberOfSeats}");
            return base.Stats() + $"{NumberOfSeats}";
        }

    }
    class Boat : Vehicle
    {
        private int _length;

        public Boat(string boat, string registernumber, string color, int numberOfWheels, int length)
            : base(boat, registernumber, color, numberOfWheels)
        {
            Vehicle1 = boat;
            _length = length;
        }
        //public Boat(string boat)
        //    : base(boat)
        //{
        //    Vehicle1 = boat;
        //}

        public int Length { get; set; }
        public string Vehicle { get; set; }
        public override string Stats()
        {
            Console.WriteLine($"Vehicle:{Vehicle1}\nLength:{Length}");
            return base.Stats() + $"{Length}";
        }


    }


}

