using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Menu
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine("*** Welcome to ReserveDesk App ***\n");
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1. Add reservation");
            Console.WriteLine("2. Delete reservation");
            Console.WriteLine("3. Check reservation");
            Console.WriteLine("4. Print all desks");
            Console.WriteLine("5. Print available desks");
            Console.WriteLine("6. Print reserved desks");
            Console.WriteLine("7. System administration");
            Console.WriteLine("8. Close the app");
        }
        public static void PrintAdminMenu()
        {
            Console.WriteLine("*** ReserveDesk App Administrator Mode ***\n");
            Console.WriteLine("With great power comes great responsibility.");
            Console.WriteLine("Think before you type.\n");
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1. Add room");
            Console.WriteLine("2. Quit Administrator Mode");
        }
        public static void WaitForAnyButton()
        {
            Console.WriteLine("(Press any button to quit)");
            Console.ReadKey();
        }
        public static char ReadOper() { return Console.ReadKey().KeyChar; }
    }
}
