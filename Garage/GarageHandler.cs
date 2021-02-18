using System;
using System.Collections.Generic;
using System.Linq;






namespace Garage
{    

    class GarageHandler
    {
        private Garage<Vehicle> garage;
        private ConsoleKeyInfo _cancelProgram;

      // Egenskaper som finns i samtliga fordonstyper
        private string color;
        private int numberOfWheels;
        private string Reg_Number;
        private bool run = true;
        private bool esc;
        private int input;
        

      // Typer av fordon
        private int airplanes;
        private int motorcycles;
        private int cars;
        private int busses;
        private int boats;

        // Skapar Constructor
        public GarageHandler()
        {
            garage = new Garage<Vehicle>(0);
        }
        public void GarageDesign()
        {
            Console.WriteLine("\n                    List of parked vehicles in the garage \n\n");

            Console.WriteLine("  Nr.  |    Vehicle type      |    Registernumber    |   Color    |   Number of Wheels    |");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            if (garage.Count() == 0)
            {
                for(int i = 0; i< garage.Capacity; i++)
                {
                    Console.WriteLine($"{i + 1}.                                                                                           |");

                }
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
        }

        //******************************************************************************************************************************
        public void Spaces(int _i,int garageCount)
        {
            int numb = 1;
            int i = _i;

            for(i= _i; i<garageCount; i++)
            {
                string space = "       ";
                Console.Write($"{numb}.");

                Console.Write(space);

                Console.Write($"{garage[i]. Vehicle1}");

                for (int k = garage[i].Vehicle1.Length; k < 25; k++)
                {
                    Console.Write("   ");
                }

                Console.WriteLine($"{garage[i].RegisterNumber}");

                for (int k = garage[i].RegisterNumber.Length; k < 24; k++)
                {
                    Console.Write("  ");
                }

                Console.Write($" {garage[i].Color}");

                for (int k = garage[i].Color.Length;k < 22; k++)
                {
                    Console.Write(" ");
                }

                Console.Write($"{garage[i].NumberOfWheels}");
                for (int k = garage[i].NumberOfWheels.ToString().Length; k < 12; k++)
                {
                    Console.Write(" ");
                }

                Console.Write("|\n");

                numb++;
            }    
        }

        // ******************************************************************************************************************************

        public string CancelableReadLine()
        {
            esc = true;
            string inputString = string.Empty;
            ConsoleKeyInfo keyInfo;

            //Console.WriteLine("Enter a string. Press <Enter> or Esc to exit.");
            do
            {
                keyInfo = Console.ReadKey(true);
                // Ignore if Alt or Ctrl is pressed.
                if ((keyInfo.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                    continue;
                if ((keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                    continue;
                // Ignore if KeyChar value is \u0000.
                if (keyInfo.KeyChar == '\u0000') continue;
                // Ignore tab key.
                if (keyInfo.Key == ConsoleKey.Tab) continue;
                // Handle backspace.
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    // Are there any characters to erase?
                    if (inputString.Length >= 1)
                    {
                        // Determine where we are in the console buffer.
                        int cursorCol = Console.CursorLeft - 1;
                        int oldLength = inputString.Length;
                        int extraRows = oldLength / 80;

                        inputString = inputString.Substring(0, oldLength - 1);
                        Console.CursorLeft = 0;
                        Console.CursorTop = Console.CursorTop - extraRows;
                        Console.Write(inputString + new String(' ', oldLength - inputString.Length));
                        Console.CursorLeft = cursorCol;
                    }
                    continue;
                }
                // Handle Escape key.
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    esc = false;
                    break;
                }
                // Handle key by adding it to input string.
                Console.Write(keyInfo.KeyChar);
                inputString += keyInfo.KeyChar;
            } while (keyInfo.Key != ConsoleKey.Enter);

            return inputString;
        }
        

        //************************************************************************************************************************
        public void RemoveVehicle(string reg_Number)
        {
            List<Vehicle> garageList = new List<Vehicle>();

            for (int i = 0; i < garage.Count(); i++)
            {
                if (garage[i].RegisterNumber != reg_Number)
                    garageList.Add(garage[i]);
            }

            garage = new Garage<Vehicle>(garage.Capacity);

            for (var i = 0; i < garageList.Count(); i++)
            {
                garage[i] = garageList[i];
            }

        }
        //*****************************************************************************************************************************

        public void PressKey()
        {
            ConsoleKeyInfo cki;

            do
            {
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                else if (cki.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    run = false;
                }

            } while (cki.Key != ConsoleKey.Enter && cki.Key != ConsoleKey.Escape);

        }

        //***************************************************************************************************************************
        public void AddVehicle()
        {
            string brand;
            string fuelType;
            int numberOfSeats;
            int numberOfEngines;
            int cylinderVolume;
            int length;


            Console.Clear();

            if (garage.Count() <= garage.Capacity)
            {
                if (garage.Count() > 0)
                {
                    Menu1();

                    Console.WriteLine("\n Would you like to enter a new vehicle into the garage?");
                    Console.Write("\n If \"YES\", press [Enter].\n If \"NO\", press any other key:\n");
                    Console.Write(" > ");

                    PressKey();
                }
                else if (garage.Count() == 0)
                {
                    Console.Clear();
                    GarageDesign();
                }

                if (run == true)
                {
                    if (garage.Count() > 0)
                    {
                        Menu1();
                    }
                    else
                    {
                        Console.Clear();
                        GarageDesign();
                    }


                    Console.WriteLine("\n Select the type of vehicle you want to park in the garage\n");
                    Console.WriteLine(" Press:");

                    Console.WriteLine("        \"1\" - Car");
                    Console.WriteLine("        \"2\" - Airplane");
                    Console.WriteLine("        \"3\" - Bus");
                    Console.WriteLine("        \"4\" - Motorcycle");
                    Console.WriteLine("        \"5\" - Boat");

                    Console.Write("        >");
                    ConsoleKeyInfo vehicleType = Console.ReadKey();


                    switch (vehicleType.Key)
                    {
                        case ConsoleKey.D1: // Car
                            {
                                Console.WriteLine("\n\n You selected: Car");

                                Console.WriteLine("\n Type the brand,color,fueltype, number of wheels and registernumber:");
                                Console.WriteLine("\nBrand: ");
                                brand = ifLetters();//Console.ReadLine();

                                Console.WriteLine("\nFueltype: ");
                                fuelType = ifLetters();//Console.ReadLine();

                                AddComponents();

                                var car = new Car("Car",Reg_Number,color,numberOfWheels,fuelType, brand);

                                garage.Park(car);

                                break;
                            }
                        case ConsoleKey.D2: // Airplane
                            {
                                Console.WriteLine("\n\n You selected: Airplane");

                                Console.WriteLine("\n Type the number of registernumber,color,number of wheels and seats:");
                                Console.WriteLine("\nNumber of seats: ");
                                numberOfSeats = ifNum();//Convert.ToInt32(Console.ReadLine());

                                AddComponents();

                                var airplane = new Airplane("Airplane",Reg_Number,color,numberOfWheels,numberOfSeats);

                                garage.Park(airplane);

                                break;
                            }
                        case ConsoleKey.D3: // Bus
                            {
                                Console.WriteLine("\n\n You selected: Bus");

                                Console.WriteLine("\n Type the number of engines, color, number of wheels and registernumber:");
                                Console.WriteLine("\n Number of engines: ");
                                numberOfEngines = ifNum();//Convert.ToInt32(Console.ReadLine());
                                fuelType = ifLetters();

                                AddComponents();

                                var bus = new Bus("Bus",Reg_Number,color,numberOfWheels,numberOfEngines,fuelType);

                                garage.Park(bus);


                                break;
                            }
                        case ConsoleKey.D4: // Motorcycle
                            {
                                Console.WriteLine("\n\n You selected: Motorcycle");

                                Console.WriteLine("\n Type the cylindervolume, color, number of wheels and registernumber:");
                                Console.WriteLine("\nCylindervolume: ");
                                cylinderVolume = ifNum();//Convert.ToDouble(Console.ReadLine());

                                AddComponents();

                                var motorcycle = new Motorcycle("Motorcycle",Reg_Number,color,numberOfWheels,cylinderVolume);

                                garage.Park(motorcycle);

                                break;
                            }
                        case ConsoleKey.D5: // Boat
                            {
                                Console.WriteLine("\n\n You selected: Boat");

                                Console.WriteLine("\n Type the length, color, number of wheels and registernumber:");
                                Console.WriteLine("\nLength:");
                                length = ifNum(); //Convert.ToDouble(Console.ReadLine());

                                AddComponents();

                                var boat = new Boat("Boat",Reg_Number,color,numberOfWheels,length) ;

                                garage.Park(boat);

                                break;
                            }
                        default:
                            {
                                Console.WriteLine(" The vehicle type that you have specified does not exist. Try again:");
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.Clear();

                if (garage.Count() > 0)
                {
                    Menu1();
                }
                else
                {
                    GarageDesign();
                }


                Console.WriteLine("\n Garage is full.");
            }

        }

        //******************************************************************************************************************************

        public string ifLetters()
        {
            bool match = true;
            string theString;
            do
            {
                theString = Console.ReadLine();

                if (theString.All(char.IsLetter))
                {
                    match = true;
                    break;
                }
                else
                {
                    match = false;
                    Console.WriteLine(" Only letters are allowed. Try again:");
                    Console.Write(" >");
                }
            } while (match == false);

            return theString;

        }
        //*****************************************************************************************************************************
        public int ifNum()
        {
            bool trueNum = true;
            int _input;
            do
            {
                var stringInput = Console.ReadLine(); //Tries to set input to the first char in an input line              

                if (!int.TryParse(stringInput, out _input))
                {
                    trueNum = false;
                    Console.WriteLine(" Only numerical digits are accepted. Try again:");
                    Console.Write(" >");
                }
                else
                {
                    trueNum = true;
                }

            } while (trueNum == false);

            return _input;
        }

        //*****************************************************************************************************************************
        public void AddComponents()
        {
            bool check = true;

            Console.WriteLine("\nColor:");
            color = ifLetters();
            Console.WriteLine("\nNumber of wheels:");
            numberOfWheels = ifNum();

            do
            {
                Console.WriteLine("\nRegisternumber:");
                Reg_Number = Convert.ToString(Console.ReadLine());

                for (int i = 0; i < garage.Count(); i++)
                {
                    if (garage[i].RegisterNumber == Reg_Number)
                    {

                        Console.WriteLine("\n You have typed the wrong registration number.");
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }
            } while (check == false);
        }

            //******************************************************************************************************************************
        public void searchByReg()
        {
            bool contains = true;
            int car = -1;

            Console.WriteLine("\n Search for a vehicle by registration number");
            Console.Write(">");

            string _regNumber = Console.ReadLine();


            do
            {

                car = -1;

                for (int i = 0; i < garage.Count(); i++)
                {
                    car++;

                    if (garage[i].RegisterNumber == _regNumber)
                    {
                        contains = true;
                        break;
                    }
                    else if (garage[i].RegisterNumber != _regNumber)
                    {
                        contains = false;
                    }
                }


                if (contains == false)
                {

                    Console.Clear();
                    Menu1();
                    Console.WriteLine($"\n No vehicle was found with the registernumber: {_regNumber}");
                    Console.WriteLine("\n Search for a specific vehicle by typing its registernumber or\n press [Esc] - go back to the Main Menu.");
                    Console.Write(" >");

                    _regNumber = CancelableReadLine();

                    if (_regNumber != "")
                        _regNumber = _regNumber.Remove(_regNumber.Length - 1);


                    if (esc == false)
                    {
                        Console.Clear();
                        Menu1();
                        break;
                    }
                }

            } while (contains == false);


            if (contains == true)
            {
                Console.Clear();
                GarageDesign();
                Spaces(car, car + 1);
                Console.WriteLine($"\n {garage[car].RegisterNumber} was found");
            }


        } 

        //********************************************************************************************************************

        // Methods for Menus (1-7)
        

        public void Menu1()
        {
            Console.Clear();

            if (garage.Count() > 0)
            {

                GarageDesign();

                Spaces(0, garage.Count());

                Console.WriteLine($"\n\n Garage has {garage.Capacity - (garage.Count())} empty parkinglots.");

            }
            else if (garage.Count() == 0 && garage.Capacity == 0)
            {
                Console.WriteLine("\n No garage exists. Choose menu 4, on the list below to create a garage.");
            }
            else
            {
                GarageDesign();
            }

        }
        
        //*************************************************************************************************************************

        public void Menu2()
        {
            Console.Clear();

            cars = 0;
            airplanes = 0;
            boats = 0;
            motorcycles = 0;
            busses = 0;

            if (garage.Capacity > 0)
            {

                foreach (var i in garage)
                {
                    if (i is Car)
                    {
                        cars++;
                    }
                    else if (i is Airplane)
                    {
                        airplanes++;
                    }
                    else if (i is Boat)
                    {
                        boats++;
                    }
                    else if (i is Motorcycle)
                    {
                        motorcycles++;
                    }
                    else if (i is Bus)
                    {
                        busses++;
                    }
                }

                if (garage.Count() > 0)
                {
                    Menu1();
                }
                else
                {
                    GarageDesign();
                }

                Console.WriteLine("\n Number of each type of vehicle that is parked inside the garage:\n");
                Console.WriteLine($" {cars} cars");
                Console.WriteLine($" {airplanes} airplanes");
                Console.WriteLine($" {boats} boats");
                Console.WriteLine($" {motorcycles} motorcycles");
                Console.WriteLine($" {busses} busses");
            }
            else
            {
                Console.WriteLine("\n No garage exists. Choose menu 4, on the list below to create a garage.");
            }

        }

        //*******************************************************************************************************************

        public void SetCapacity(int capacity)
        {
            garage.Capacity = capacity;
        }
        //*******************************************************************************************************************

        public void Menu3()
        {
            ConsoleKeyInfo cki;
            Console.Clear();
            bool notEnter = false;

            if (garage.Capacity > 0)
            {

                if (garage.Count() > 0)
                {
                    Menu1();
                }
                else
                {
                    GarageDesign();
                }

                do
                {
                    Console.Write("\n Press \"1\" - to add a vehicle\n       \"2\" - remove a vehicle\n       \"[Esc]\" - back to Main Menu\n");
                    Console.Write("       >");

                    cki = Console.ReadKey();

                    if (cki.Key == ConsoleKey.D1 && garage.Count() < garage.Capacity)
                    {
                        run = true;
                        notEnter = true;

                        Console.Clear();

                        while (run == true && garage.Count() != garage.Capacity)
                        {

                            AddVehicle();
                        }

                        if (garage.Count() == garage.Capacity)
                        {
                            Console.Clear();

                            Menu1();

                            Console.WriteLine("\n The garage is full.");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Menu1();
                    }

                    if (cki.Key == ConsoleKey.D2 && garage.Count() > 0)
                    {
                        Console.Clear();
                        notEnter = true;

                        Menu1();

                        Console.Write("\n Type the registernumber of the vehicle that you want to remove: ");
                        string reg = Console.ReadLine();

                        RemoveVehicle(reg);

                        while (garage.Count() > 0)
                        {

                            Console.Clear();
                            Menu1();

                            Console.WriteLine($"\n There are {garage.Count()} vehicles left in the garage.");
                            Console.WriteLine("\n Would you like to remove any vehicle?");

                            Console.Write("\n If \"YES\", press [Enter].\n If \"NO\", press [ESC]:");

                            ConsoleKeyInfo cki2;

                            cki2 = Console.ReadKey();

                            if (cki2.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();

                                Menu1();

                                Console.Write("\n Type the registernumber of the vehicle that you want to remove: ");
                                reg = Console.ReadLine();
                                RemoveVehicle(reg);
                            }
                            else if (cki2.Key == ConsoleKey.Escape)
                            {
                                notEnter = false; //// ???
                                Console.Clear();
                                Menu1();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Menu1();
                                //continue; ;
                            }

                            if (garage.Count() == 0)
                            {
                                Console.Clear();

                                GarageDesign();

                                Console.WriteLine("\n No vehicles left to remove. The garage is empty.");
                                break;
                            }
                        }
                    }
                    else if (cki.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menu1();
                    }

                } while (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2 && cki.Key != ConsoleKey.Escape);


                if (garage.Count() == 0)
                {
                    Console.Clear();

                    GarageDesign();

                    if (notEnter == false)
                    {
                        Console.WriteLine("\n The garage is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\n The garage is empty. No vehicles to remove.");
                    }
                }
                else
                {
                    Menu1();
                }
            }
            else
            {
                Console.WriteLine("\n No garage exists. To \"park/remove\" a vehicle, you need to have a garage.\n Choose menu 4, on the list below to create a garage.");
            }

        }
        //****************************************************************************************************************************

        public void Menu4()
        {
            if (garage.Capacity > 0 && garage.Count() > 0)
            {
                Menu1();
            }
            else if (garage.Capacity > 0 && garage.Count() == 0)
            {
                GarageDesign();
            }

            Console.Write("\n Create a new garage with a new amount of parkinglots: ");
            int cap = ifNum(); //Convert.ToInt32(Console.ReadLine());

            if (garage.Capacity > 0)
            {
                garage = new Garage<Vehicle>(cap);
            }
            else
            {
                garage.Capacity = cap;
            }

            Console.Clear();

            GarageDesign();

            Console.Write($"\n You've created a new garage with a {garage.Capacity} parkinglots.\n");
        }
        // ************************************************************************************************************************************************************
        public void Menu5()
        {
            if (garage.Capacity > 0 && garage.Count() > 0)
            {
                Console.Clear();
                Menu1();
                searchByReg();
            }
            else if (garage.Capacity == 0)
            {
                Console.WriteLine("\n No garage exists. Choose menu 4, on the list below to create a garage:");
            }
            else if (garage.Count() == 0)
            {
                GarageDesign();
                Console.WriteLine("\n The are no vehicles parked in the garage.");
            }

        }
        //*************************************************************************************************************************

        public void Menu7()
        {
            Console.Clear();
            Console.WriteLine("\n               Do you want to quit the program?\n");
            Console.WriteLine("\n \"YES\" - press [Enter]            \"NO\" - press [Esc] to return back to the main menu\n");
            Console.WriteLine(" ");
            Console.Write(" >");

            do
            {
                _cancelProgram = Console.ReadKey();

            } while (_cancelProgram.Key != ConsoleKey.Enter && _cancelProgram.Key != ConsoleKey.Escape);


            switch (_cancelProgram.Key)
            {
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        break;
                    }
            }

            Console.Clear();

            if (garage.Count() > 0)
            {
                Menu1();
            }
            else if (garage.Capacity > 0)
            {
                GarageDesign();
            }

        }

        //***********************************************************************************************************************

        public void MainMenu()
        {
            do
            {
                input = TextMenu();


                if (input > 7 || input < 1)
                {


                    if (garage.Count() > 0)
                    {
                        Menu1();
                    }
                    else if (garage.Capacity > 0)
                    {
                        GarageDesign();
                    }

                    Console.WriteLine("\n Only numbers 1-6 are accepted.\n");

                }

                else if (input <= 7 && input > 0)
                {

                    switch (input)
                    {

                        case 1:
                            {
                                Menu1();
                                break;
                            }

                        case 2:
                            {
                                Menu2();
                                break;
                            }

                        case 3:
                            {
                                Menu3();
                                break;
                            }

                        case 4:
                            {
                                Menu4();
                                break;
                            }

                        case 5:
                            {
                                Menu5();
                                break;
                            }

                        case 6:
                            {
                                Console.Clear();
                                GarageDesign();
                                var queryVehicles = from vehicle in garage
                                                    select vehicle.Color;
                                Console.WriteLine($"\n {queryVehicles}\n");

                                break;
                            }

                        case 7:
                            {
                                Menu7();
                                break;
                            }
                    }
                }
            } while (run == true);

            MainMenu();

        }
        //*************************************************************************************************************************

        public int TextMenu()
        {


            Console.WriteLine("\n Press: \"1\" - Menu 1. Listing all parked vehicles in a garage.");
            Console.WriteLine("        \"2\" - Menu 2. A list of the amounts of each vehicletype that is parked in the garage.");
            Console.WriteLine("        \"3\" - Menu 3. Add/remove a vehicle.");
            Console.WriteLine("        \"4\" - Menu 4. Create a garage, and set the number of parking lots.");
            Console.WriteLine("        \"5\" - Menu 5. Find a specific vehicle by registernumber.");
            Console.WriteLine("        \"6\" - Menu 6. Search a vehicle given it's properties, for example, \"all black vehicles with 4 wheels\".");
            Console.WriteLine("        \"7\" - Quit");

            Console.Write("        >");

            ConsoleKeyInfo choice;

            choice = Console.ReadKey();

            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    {
                        input = 1;
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        input = 2;
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        input = 3;
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        input = 4;
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        input = 5;
                        break;
                    }
                case ConsoleKey.D6:
                    {
                        input = 6;
                        break;
                    }
                case ConsoleKey.D7:
                    {
                        input = 7;
                        break;
                    }
            }

            Console.Clear();

            return input;

        }

        //*********************************************************************************************************************

    }
}
