using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Building building = new Building();

            building.AddRoom("Test 1");
            building.AddRoom("Test 2");
            building.AddRoom("Test 3");

            char oper;
            Menu.PrintMenu();

            oper = Console.ReadKey().KeyChar;

            while(oper != '7')
            {
                Console.Clear();

                switch (oper)
                {
                    case '1':
                        building.AddReservation();
                        Menu.WaitForAnyButton();
                        break;
                    case '2':
                        building.DeleteReservation();
                        Menu.WaitForAnyButton();
                        break;
                    case '3':
                        building.CheckReservation();
                        Menu.WaitForAnyButton();
                        break;
                    case '4':
                        building.PrintAllDesks();
                        Menu.WaitForAnyButton();
                        break;
                    case '5':
                        building.PrintAvailableDesks();
                        Menu.WaitForAnyButton();
                        break;
                    case '6':
                        building.PrintReservedDesks();
                        Menu.WaitForAnyButton();
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Menu.PrintMenu();

                oper = Console.ReadKey().KeyChar;
            }
        }
    }
}
