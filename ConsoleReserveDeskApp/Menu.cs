using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Menu
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to ReserveDesk App \n");
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1. Add reservation");
            Console.WriteLine("2. Delete reservation");
            Console.WriteLine("3. Check reservation");
            Console.WriteLine("4. Print all desks");
            Console.WriteLine("5. Print available desks");
            Console.WriteLine("6. Print reserved desks");
            Console.WriteLine("7. Close the app");
        }
        public static void WaitForAnyButton()
        {
            Console.WriteLine("(Press any button to quit)");
            Console.ReadKey();
        }
    }
}
