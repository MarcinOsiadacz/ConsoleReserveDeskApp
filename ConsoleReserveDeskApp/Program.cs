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
            HotDesk desk = new HotDesk(3);
            desk.Reserve();
            desk.Print();
            desk.Release();
            desk.Print();


            Building building = new Building();
            building.AddRoom("Test 99");

            char mainMenuOper;
            Menu.PrintMainMenu();

            mainMenuOper = Menu.ReadOper();

            while(mainMenuOper != '8')
            {
                Console.Clear();

                switch (mainMenuOper)
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
                    case '7':
                        // Nested menu for building management
                        char adminMenuOper;
                        Menu.PrintAdminMenu();

                        adminMenuOper = Menu.ReadOper();

                        while (adminMenuOper != '2')
                        {
                            Console.Clear();

                            switch (adminMenuOper)
                            {
                                case '1':
                                    building.ReadRoom();
                                    Menu.WaitForAnyButton();
                                    break;
                                default:
                                    break;
                            }

                            Console.Clear();
                            Menu.PrintAdminMenu();

                            adminMenuOper = Menu.ReadOper();
                        }
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Menu.PrintMainMenu();

                mainMenuOper = Menu.ReadOper();
            }
        }
    }
}
