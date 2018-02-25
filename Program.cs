using System;

namespace BonusLab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Parking Garage!");
            Start();
        }

        //Starts the program and allows for recursion
        public static void Start()
        {
            FindSpot(CarType());
            Again();
        }

        //This asks the user which car type they are parking and creates a
        //new Vehicle object of the type selected and returns it
        public static Vehicles CarType()
        {
            Console.WriteLine("What kind of vehicle are you driving today?\nPlease select an option\n" +
                              "1) Motorcycle\n2) Compact Car\n3) Bus");
            if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= 3)
            {
                if (input == 1)
                {
                    //Console.WriteLine("Made motorcycle");
                    return new Motorcycle();
                }
                else if (input == 2)
                {
                    //Console.WriteLine("Made Car");
                    return new Car();
                }
                else
                {
                    //Console.WriteLine("Made Bus");
                    return new Bus();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number 1-3.");
                return CarType();
            }
        }

        //This is the main logic of the program.  The chosen Vehicles object is passed in.
        public static void FindSpot(Vehicles vehicle)
        {
            //If the vehicle is a motorcycle
            if (vehicle.Size == 1)
            {
                foreach (Level level in ParkingStructure.Structure)
                {
                    foreach (ParkingSpot spot in level.SpotArray)
                    {
                        if (spot.Open)
                        {
                            //The parking spot will be marked as taken
                            spot.Open = false;
                            Console.WriteLine("Your Vehicle is on Level {0} and in spot {1}.", level.FloorNumber, spot.SpotNumber);
                            return;
                        }
                    }
                }
                //Inform the user if there is no open spot
                Console.WriteLine("Sorry there are no open spots for your vehicle");
                return;
            }
            //If the vehicle is a compact
            else if (vehicle.Size == 2)
            {
                foreach (Level level in ParkingStructure.Structure)
                {
                    foreach (ParkingSpot spot in level.SpotArray)
                    {
                        if (spot.Open && spot.Size >= 2)
                        {
                            spot.Open = false;
                            Console.WriteLine("Your Vehicle is on Level {0} and in spot {1}.", level.FloorNumber, spot.SpotNumber);
                            return;
                        }
                    }
                }
                Console.WriteLine("Sorry there are no open spots for your vehicle");
                return;
            }
            //If the vehicle is a bus
            else if (vehicle.Size==3)
            {
                foreach (Level level in ParkingStructure.Structure)
                {
                    foreach (ParkingSpot spot in level.SpotArray)
                    {
                        if (spot.Open && spot.Size == 3)
                        {
                            //Check to see if 5 parking spots in a row are open and are large spots
                            bool inRow = true;
                            int i = spot.SpotNumber;
                            while (inRow == true && i <= spot.SpotNumber + 3 && i < level.SpotArray.Length)
                            {
                                if (!level.SpotArray[i].Open == true || level.SpotArray[i].Size != 3)
                                {
                                    inRow = false;
                                }
                                if (i == spot.Size + 3)
                                {
                                    Console.WriteLine("Your Vehicle is on Level {0} and in spots {1} - {2}.", level.FloorNumber, spot.SpotNumber, spot.SpotNumber + 4);
                                    //Mark all 5 spots as taken
                                    for (int j = spot.SpotNumber-1; j <= spot.SpotNumber +3; j++)
                                    {
                                        level.SpotArray[j].Open = false;
                                    }
                                    return;
                                }
                                i++;
                            }
                        }
                    }
                }
                Console.WriteLine("Sorry there are no open spots for your vehicle");
                return;
            }

        }

        //Ask the user if they would like to park another car.  Enacts recursion
        public static void Again()
        {
            Console.WriteLine("Press 'Y' to park another car or any other key to end.");
            string input = Console.ReadLine().ToLower();
            if (input=="y")
            {
                Start();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }

        //These items are from another way of parking the cars. Instead of using vehicle objects it just uses the user input option.
        //To use this strategy, the Start method should call the ParkCar() method followed by the Again() method.
        //public static void ParkCar()
        //{
        //    Console.WriteLine("What kind of vehicle are you driving today?\nPlease select an option\n" +
        //                      "1) Motorcycle\n2) Compact Car\n3) Bus");
        //    if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= 3)
        //    {
        //        if (input == 1)
        //        {
        //            ParkMotorcycle();
        //        }
        //        else if (input == 2)
        //        {
        //            ParkCompact();
        //        }
        //        else
        //        {
        //            ParkBus();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid input. Please enter a number 1-3.");
        //    }
        //}

        //public static void ParkMotorcycle()
        //{
        //    foreach (Level level in ParkingStructure.Structure)
        //    {
        //        foreach (ParkingSpot spot in level.SpotArray)
        //        {
        //            if (spot.Open)
        //            {
        //                spot.Open = false;
        //                Console.WriteLine("Your Vehicle is on Level {0} and in spot {1}.", level.FloorNumber, spot.SpotNumber);
        //                return;
        //            }
        //        }
        //    }
        //    Console.WriteLine("Sorry there are no open spots for your vehicle");
        //    return;
        //}

        //public static void ParkCompact()
        //{
        //    foreach (Level level in ParkingStructure.Structure)
        //    {
        //        foreach (ParkingSpot spot in level.SpotArray)
        //        {
        //            if (spot.Open && spot.Size >= 2)
        //            {
        //                spot.Open = false;
        //                Console.WriteLine("Your Vehicle is on Level {0} and in spot {1}.", level.FloorNumber, spot.SpotNumber);
        //                return;
        //            }
        //        }
        //    }
        //    Console.WriteLine("Sorry there are no open spots for your vehicle");
        //    return;
        //}

        //public static void ParkBus()
        //{
        //    foreach (Level level in ParkingStructure.Structure)
        //    {
        //        foreach (ParkingSpot spot in level.SpotArray)
        //        {
        //            if (spot.Open && spot.Size == 3)
        //            {
        //                bool inRow = true;
        //                int i = spot.SpotNumber;
        //                while (inRow == true && i <= spot.SpotNumber + 3 && i < level.SpotArray.Length)
        //                {
        //                    if (!level.SpotArray[i].Open == true || level.SpotArray[i].Size != 3)
        //                    {
        //                        inRow = false;
        //                    }
        //                    if (i == spot.Size + 3)
        //                    {
        //                        Console.WriteLine("Your Vehicle is on Level {0} and in spots {1} - {2}.", level.FloorNumber, spot.SpotNumber, spot.SpotNumber + 4);
        //                        for (int j = i; j > i - 4; j--)
        //                        {
        //                            level.SpotArray[j].Open = false;
        //                        }
        //                        return;
        //                    }
        //                    i++;
        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine("Sorry there are no open spots for your vehicle");
        //    return;
        //}
    }
}
