using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.IO;

namespace Final_Project
{
    class Manufacturing// Class representing a manufacturing facility
    {
        public int facilityID;// Properties representing the state of a manufacturing facility
        public int bodyFrameInventory;
        public int stringInventory;
        public int pickupInventory;
        public bool inOperation;
        public static List<Manufacturing> factory = new List<Manufacturing>();// Static list to store instances of Manufacturing class
        public Manufacturing()// Default constructor initializing facility with default values
        {
            facilityID = 1;
            bodyFrameInventory = 20;
            stringInventory = 150;
            pickupInventory = 50;
            inOperation = false;
        }
        public Manufacturing(int f, int b, int s, int p, bool o)// Parameterized constructor to create a facility with specified values
        {
            facilityID = f;
            bodyFrameInventory = b;
            stringInventory = s;
            pickupInventory = p;
            inOperation = o;
        }
        public static bool toggleFactoryFloor(int facilityID) // Method to toggle the operational status of a factory floor
        {
            Manufacturing currentFacility = Manufacturing.factory[facilityID - 1]; // Retrieve the current facility based on ID
            if (!currentFacility.inOperation)// Check if the facility is not in operation
            {
                Console.WriteLine("The factory is currently not in operation.");// Prompt user to begin operations
                Console.WriteLine("Would you like to begin operations on the factory floor?");
                string uResponse = Console.ReadLine();
                if (uResponse == "yes")// Process user response
                {
                    currentFacility.inOperation = true;
                    Console.WriteLine("The factory floor is starting operations...");
                }
                else if (uResponse == "no")
                { Console.WriteLine("The factory floor will remain not in operation"); }
            }
            else if (currentFacility.inOperation)// Check if the facility is in operation
            {
                Console.WriteLine("The factory is currrently operating at normal levels.");// Prompt user to shut down operations
                Console.WriteLine("Would you like to shutdown the factory floor?");
                string uResponse = Console.ReadLine();
                if (uResponse == "yes")// Process user response
                {
                    currentFacility.inOperation = false;
                    Console.WriteLine("The factory floor is shutting down operations...");
                }
                else if (uResponse == "no")
                { Console.WriteLine("The factory floor will remain in operation"); }
            }
            return currentFacility.inOperation;// Return the updated operational status
        }
        public static void displayFactoryInformation(List<Manufacturing> fList)// Method to display information for all manufacturing facilities
        {
            foreach (Manufacturing f in fList)
            {
                Console.WriteLine();
                Console.WriteLine("Facility ID:\t{0}", f.facilityID);
                Console.WriteLine("Operating:\t{0}", f.inOperation);
                Console.WriteLine();
                Console.WriteLine("Current Inventory:");
                Console.WriteLine("Body Frame Inventory:\t{0}", f.bodyFrameInventory);
                Console.WriteLine("String Inventory:\t{0}", f.stringInventory);
                Console.WriteLine("Pickup Inventory:\t{0}", f.pickupInventory);
                Console.WriteLine();
            }
        }
        public static void alterInventory(int facilityID)// Method to alter the inventory of a specific facility
        {
            Manufacturing currentFacility = Manufacturing.factory[facilityID - 1];// Retrieve the current facility based on ID
            Console.WriteLine("What would you like to change the inventory of?");// Prompt user to choose the type of inventory to alter
            Console.WriteLine("1.\tBody Frames");
            Console.WriteLine("2.\tStrings");
            Console.WriteLine("3.\tPickups");
            int uResponse = Convert.ToInt32(Console.ReadLine());
            if (uResponse == 1)// Process user choice
            {
                Console.WriteLine("Current Inventory: {0}", currentFacility.bodyFrameInventory);
                Console.WriteLine("1.\tIncrease Inventory");
                Console.WriteLine("2.\tDecrease Inventory");
                int uIncreaseOrDecrease = Convert.ToInt32(Console.ReadLine());
                if (uIncreaseOrDecrease == 1)
                {
                    Console.WriteLine("How many would you like to add?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.bodyFrameInventory += uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.bodyFrameInventory);
                }
                if (uIncreaseOrDecrease == 2)
                {
                    Console.WriteLine("How many would you like to subtract?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.bodyFrameInventory -= uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.bodyFrameInventory);
                }
            }
            else if (uResponse == 2)
            {
                Console.WriteLine("Current Inventory: {0}", currentFacility.stringInventory);
                Console.WriteLine("1.\tIncrease Inventory");
                Console.WriteLine("2.\tDecrease Inventory");
                int uIncreaseOrDecrease = Convert.ToInt32(Console.ReadLine());
                if (uIncreaseOrDecrease == 1)
                {
                    Console.WriteLine("How many would you like to add?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.stringInventory += uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.stringInventory);
                }
                if (uIncreaseOrDecrease == 2)
                {
                    Console.WriteLine("How many would you like to subtract?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.stringInventory -= uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.stringInventory);
                }
            }
            else if (uResponse == 3)
            {
                Console.WriteLine("Current Inventory: {0}", currentFacility.pickupInventory);
                Console.WriteLine("1.\tIncrease Inventory");
                Console.WriteLine("2.\tDecrease Inventory");
                int uIncreaseOrDecrease = Convert.ToInt32(Console.ReadLine());
                if (uIncreaseOrDecrease == 1)
                {
                    Console.WriteLine("How many would you like to add?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.pickupInventory += uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.pickupInventory);
                }
                if (uIncreaseOrDecrease == 2)
                {
                    Console.WriteLine("How many would you like to subtract?");
                    int uNum = Convert.ToInt32(Console.ReadLine());
                    currentFacility.pickupInventory -= uNum;
                    Console.WriteLine("Current Inventory: {0}", currentFacility.pickupInventory);
                }
            }
            else
                Console.WriteLine("Invalid Input");
        }
        public static void openNewFacility()// Method to open a new manufacturing facility
        {
            int newFacilityID = Manufacturing.factory.Count + 1;// Generate a new facility ID
            int newBodyFrameInventory = 0;// Initialize new facility with default values
            int newStringInventory = 0;
            int newPickupInventory = 0;
            bool newInOperation = false;
            Manufacturing newFactory = new Manufacturing(newFacilityID, newBodyFrameInventory, newStringInventory, newPickupInventory,newInOperation);  // Create a new Manufacturing object with specified values
            factory.Add(newFactory);// Add the new facility to the list
            displayFactoryInformation(factory);// Display information about all facilities
        }
    }
    class CustomGuitar
    {
        public string bodyShape;// Properties representing the characteristics of a custom guitar
        public int stringCount;
        public int pickupCount;
        public bool whammyBar;
        public double price;
        public static List<CustomGuitar> guitars = new List<CustomGuitar>();// Static list to store instances of CustomGuitar class
        public CustomGuitar()// Default constructor initializing guitar with default values
        {
            bodyShape = "Les Paul Inspiration";
            stringCount = 6;
            pickupCount = 2;
            whammyBar = false;
            price = 0;
        }
        public CustomGuitar(string b, int s, int p, bool w, double d)// Parameterized constructor to create a guitar with specified values
        {
            bodyShape = b;
            stringCount = s;
            pickupCount = p;
            whammyBar = w;
            price = d;
        }
        static void Main(string[] args)
        {
            Manufacturing facility1 = new Manufacturing(1, 20, 150, 50,false);// Create instances of Manufacturing representing different facilities
            Manufacturing facility2 = new Manufacturing(2, 30, 200, 70, false);
            Manufacturing facility3 = new Manufacturing(3, 25, 180, 60, false);
            Manufacturing.factory.Add(facility1);// Add facilities to the factory list
            Manufacturing.factory.Add(facility2);
            Manufacturing.factory.Add(facility3);
            while (true)
            {//main menu
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine("\r\n  ________            .__     /\\           ________      .__  __                       \r\n /  _____/_____ ___  _|__| ___)/  ______  /  _____/ __ __|__|/  |______ _______  ______\r\n/   \\  ___\\__  \\\\  \\/ /  |/    \\ /  ___/ /   \\  ___|  |  \\  \\   __\\__  \\\\_  __ \\/  ___/\r\n\\    \\_\\  \\/ __ \\\\   /|  |   |  \\\\___ \\  \\    \\_\\  \\  |  /  ||  |  / __ \\|  | \\/\\___ \\ \r\n \\______  (____  /\\_/ |__|___|  /____  >  \\______  /____/|__||__| (____  /__|  /____  >\r\n        \\/     \\/             \\/     \\/          \\/                    \\/           \\/ \r\n");
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("ADMIN CONSOLE");
                Console.WriteLine();
                Console.WriteLine("What would you like to do today");
                Console.WriteLine("1. Change Inventory");
                Console.WriteLine("2. Place Custom Order");
                Console.WriteLine("3. Factory Operation Status");
                Console.WriteLine("4. Display Orders");
                Console.WriteLine("5. Display Facility Information");
                Console.WriteLine("6. Open new Facility");
                try
                {
                    int uInput = Convert.ToInt32(Console.ReadLine());
                    int enterGuitarAmount = 0;
                    bool wantsToContinue = true;
                    while (true)
                    {
                        if (Convert.ToInt32(uInput) == 1)
                        {
                            Console.WriteLine("Which factory would you like to change the inventory of? (Enter Facility ID)");
                            int uNum = Convert.ToInt32(Console.ReadLine());
                            Manufacturing.alterInventory(uNum);
                        }
                        else if (Convert.ToInt32(uInput) == 2)
                        {
                            while (wantsToContinue == true)
                            {
                                Console.WriteLine("How many guitars would you like to enter?");
                                enterGuitarAmount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Which facility would you like to create these guitars at? (Enter Facility ID)");
                                int uNum = Convert.ToInt32(Console.ReadLine());
                                enterCustomGuitar(enterGuitarAmount,uNum);
                                Console.WriteLine("Enter more Custom Orders?");
                                string uInputYorN = Console.ReadLine();
                                if (uInputYorN == "yes")
                                {
                                    wantsToContinue = true;
                                }
                                else if (uInputYorN == "no")
                                {
                                    wantsToContinue = false;
                                }
                            }
                            wantsToContinue = true;
                        }
                        else if (Convert.ToInt32(uInput) == 3)
                        {
                            Console.WriteLine("Which facility would you like to change the operational status of? (Enter Facility ID)");
                            int uNum = Convert.ToInt32(Console.ReadLine());
                            Manufacturing.toggleFactoryFloor(uNum);
                        }
                        else if (Convert.ToInt32(uInput) == 4)
                        {
                            displayOrders(guitars);
                        }
                        else if (Convert.ToInt32(uInput) == 5)
                        {
                            Manufacturing.displayFactoryInformation(Manufacturing.factory);
                        }
                        else if (Convert.ToInt32(uInput) == 6)
                        {
                            Manufacturing.openNewFacility();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        Console.WriteLine();//returns user to menu
                        Console.WriteLine("ADMIN CONSOLE");
                        Console.WriteLine();
                        Console.WriteLine("What would you like to do today");
                        Console.WriteLine("1. Change Inventory");
                        Console.WriteLine("2. Place Custom Order");
                        Console.WriteLine("3. Factory Operation Status");
                        Console.WriteLine("4. Display Orders");
                        Console.WriteLine("5. Display Facility Information");
                        Console.WriteLine("6. Open new Facility");
                        uInput = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch { Console.WriteLine("Invalid Input"); }
            }
        }
        
        public static List<CustomGuitar> enterCustomGuitar(int y, int facilityID)//method to create more guitar orders
        {
            Manufacturing currentFacility = Manufacturing.factory[facilityID - 1];// Retrieve the current facility based on ID

            string aBodyShape = "";
            int aStringCount = 0;
            int aPickupCount = 0;
            bool aWhammyBar = false;
            double pBodyShape = 0;
            double pStringCount = 0;
            double pPickupCount = 0;
            double pWhammyBar = 0;
            for (int i = 0; i < y; i++)
            {//user entry for guitar order
                Console.WriteLine("What kind of body shape?");
                string[] bodyShape = { "1. Les Paul Inspiration", "2. Strat Inspiration", "3. The V", "4. The Dimebag", "5. Jazz Master" };
                printArray(bodyShape);
                int uBodyShape = Convert.ToInt32(Console.ReadLine());
                if (currentFacility.bodyFrameInventory > 0 && currentFacility.stringInventory >= 8 && currentFacility.pickupInventory >= 3)//ensure there is inventory
                {
                    if (uBodyShape == 1)
                    {
                        aBodyShape = "Les Paul Inspiration";
                        pBodyShape = 300.00;
                        currentFacility.bodyFrameInventory -= 1;
                    }
                    else if (uBodyShape == 2)
                    {
                        aBodyShape = "Strat Inspiration";
                        pBodyShape = 250.00;
                        currentFacility.bodyFrameInventory -= 1;
                    }
                    else if (uBodyShape == 3)
                    {
                        aBodyShape = "The V";
                        pBodyShape = 750.00;
                        currentFacility.bodyFrameInventory -= 1;
                    }
                    else if (uBodyShape == 4)
                    {
                        aBodyShape = "The Dimebag";
                        pBodyShape = 700.00;
                        currentFacility.bodyFrameInventory -= 1;
                    }
                    else if (uBodyShape == 5)
                    {
                        aBodyShape = "Jazz Master";
                        pBodyShape = 550.00;
                        currentFacility.bodyFrameInventory -= 1;
                    }
                    else
                        Console.WriteLine("Invalid Input");
                    Console.WriteLine("How many strings?");
                    int[] stringCount = { 6, 7, 8 };
                    printArray(stringCount);
                    int uStringCount = Convert.ToInt32(Console.ReadLine());
                    if (uStringCount == 6)
                    {
                        aStringCount = 6;
                        pStringCount = 10.00;
                        currentFacility.stringInventory -= 6;
                    }
                    else if (uStringCount == 7)
                    {
                        aStringCount = 7;
                        pStringCount = 12.00;
                        currentFacility.stringInventory -= 7;

                    }
                    else if (uStringCount == 8)
                    {
                        aStringCount = 8;
                        pStringCount = 13.00;
                        currentFacility.stringInventory -= 8;
                    }
                    else
                        Console.WriteLine("Invalid Input");
                    Console.WriteLine("How many pickups");
                    int[] pickupCount = { 1, 2, 3 };
                    printArray(pickupCount);
                    int uPickupCount = Convert.ToInt32(Console.ReadLine());
                    if (uPickupCount == 1)
                    {
                        aPickupCount = 1;
                        pPickupCount = 80.00;
                        currentFacility.pickupInventory -= 1;
                    }
                    else if (uPickupCount == 2)
                    {
                        aPickupCount = 2;
                        pPickupCount = 150.00;
                        currentFacility.pickupInventory -= 2;
                    }
                    else if (uPickupCount == 3)
                    {
                        aPickupCount = 3;
                        pPickupCount = 220.00;
                        currentFacility.pickupInventory -= 3;
                    }
                    else
                        Console.WriteLine("Invalid Input");
                }
                else
                { 
                    Console.WriteLine("Not Enough Inventory at Facility");
                    return guitars; }
                Console.WriteLine("Would you like a whammy bar? (true or false)");
                bool uWhammyBar = Convert.ToBoolean(Console.ReadLine());
                if (uWhammyBar == true)
                { 
                    aWhammyBar = true;
                    pWhammyBar = 10.00;
                }
                else if (uWhammyBar == false)
                { 
                    aWhammyBar = false;
                    pWhammyBar = 0;
                }
                double aPrice = calculateCost(pBodyShape, pStringCount, pPickupCount, pWhammyBar);
                CustomGuitar gi = new CustomGuitar(aBodyShape, aStringCount, aPickupCount, aWhammyBar, aPrice);
                guitars.Add(gi);//adds guitar to list
                Console.WriteLine();
                gi.displayGuitar();//user visually verfies entered info
                Console.WriteLine();
            }
            return guitars;
        }
        public static double calculateCost(double pBodyShape, double pStringCount, double pPickupCount, double pWhammyBar)// Method to calculate the cost of a custom guitar
        {
            double aPrice = pBodyShape + pStringCount + pPickupCount + pWhammyBar;
            return aPrice;
        }
       
        public static void printArray(string[] xArray)// Method to print an array of strings
        {
            foreach (string i in xArray)
                Console.WriteLine(i);
        }
        public static void printArray(int[] xArray)// Method to print an array of int
        {
            foreach (int i in xArray)
                Console.WriteLine(i);
        }
        public static void displayOrders(List<CustomGuitar> guitars)// Method to display information about custom guitar orders
        {
            Console.WriteLine();
            Console.WriteLine("There are {0} orders", guitars.Count);
            Console.WriteLine();
            foreach (CustomGuitar guitar in guitars)
            {
                //Console.WriteLine(guitar);
                Console.WriteLine("Body Shape:\t{0}", guitar.bodyShape);
                Console.WriteLine("String Count:\t{0}", guitar.stringCount);
                Console.WriteLine("Pickup Count:\t{0}", guitar.pickupCount);
                Console.WriteLine("Whammy Bar:\t{0}", guitar.whammyBar);
                Console.WriteLine("Price:\t\t${0}",guitar.price);
                Console.WriteLine();
            }
        }
        public void displayGuitar()// Method to display details of a single guitar
        {
            Console.WriteLine("Body Shape:\t{0}", bodyShape);
            Console.WriteLine("String Count:\t{0}",stringCount);
            Console.WriteLine("Pickup Count:\t{0}", pickupCount);
            Console.WriteLine("Whammy Bar:\t{0}", whammyBar);
            Console.WriteLine("Price:\t\t${0}", price);
        }
    }
}
