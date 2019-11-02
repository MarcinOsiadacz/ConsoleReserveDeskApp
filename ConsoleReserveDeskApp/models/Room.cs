using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Room : IReservationManagement
    {
        // Room class is used to manage desks
        private string name;
        private const int maxNumberOfDesks = 20;
        // allDesks list stores objects of all Desk derived classes
        private List<Equipment> allDesks = new List<Equipment>();
        // selectedDesk field stores the number of the desk selected by user in reservation related methods.
        private int selectedDesk;

        public string Name { get => name; set => name = value; }

        public Room(string name = "")
        {
            this.Name = name;
            // Number 0 means unassigned desk.
            this.selectedDesk = 0;

            for (int i = 0; i < maxNumberOfDesks/2; i++)
            {   
                if (i % 2 == 0)
                {
                    this.allDesks.Add(new Desk(number: i + 1));
                }
                else
                {
                    this.allDesks.Add(new HotDesk(number: i + 1));
                }
            }
        }
        public void PrintAllDesks()
        {
            if (this.allDesks.Count > 0)
            {
                foreach (Equipment desk in this.allDesks) { desk.Print(); }

                Console.WriteLine($"Total desks: {this.allDesks.Count}\n");
            }
            else { Console.WriteLine("There are no desks in this room"); }

        }
        public void PrintAvailableDesks()
        {
            if (this.allDesks.Count > 0)
            {
                int availableDeskCounter = 0;

                foreach (Equipment desk in this.allDesks)
                {
                    // HotDesk instances are always available even if they are reserved on certain dates
                    if (desk.GetType() == typeof(HotDesk))
                    {
                        desk.Print();
                        availableDeskCounter++;
                    }
                    else
                    { // Desk instances are available only if IsReserved method returns false
                        if (!desk.IsReserved())
                        {
                            desk.Print();
                            availableDeskCounter++;
                        }
                    }
                }

                Console.WriteLine($"Total available desks: {availableDeskCounter}\n");
            }
            else { Console.WriteLine("There are no desks in this room"); }
        }
        public void PrintReservedDesks()
        {
            if (this.allDesks.Count > 0)
            {
                int reservedDeskCounter = 0;

                foreach (Equipment desk in this.allDesks)
                {
                    if (desk.IsReserved())
                    {
                        desk.Print();
                        reservedDeskCounter++;
                    }
                }

                Console.WriteLine($"Total reserved desks: {reservedDeskCounter}\n");
            }
            else { Console.WriteLine("There are no desks in this room"); }
        }
        public void AddReservation()
        {
            Console.WriteLine("*** Add reservation ***");
            PrintAvailableDesks();
            SelectDesk();

            if(this.selectedDesk != 0) { this.allDesks[this.selectedDesk - 1].Reserve(); }
        }
        public void SelectDesk()
        {
            int tmpSelectedDesk;

            Console.WriteLine("Please enter a number of the desk (or 0 to quit): ");
            string strDesk = Console.ReadLine();

            if (!Int32.TryParse(strDesk, out tmpSelectedDesk)) { Console.WriteLine("Invalid number"); }
            else
            {
                this.selectedDesk = tmpSelectedDesk;

                if(this.selectedDesk < 0 || this.selectedDesk > maxNumberOfDesks)
                {
                    if(this.selectedDesk != 0)
                    {
                        this.selectedDesk = 0;
                        Console.WriteLine("Desk does not exist");
                    }
                }
            }
        }
        public void CheckReservation()
        {
            Console.WriteLine("*** Check reservation ***");
            SelectDesk();

            if (this.selectedDesk != 0)
            {
                this.allDesks[this.selectedDesk - 1].Print();
                ResetSelectedDesk();
            }
        }
        public void DeleteReservation()
        {
            Console.WriteLine("*** Delete reservation ***");
            PrintReservedDesks();
            SelectDesk();

            if (this.selectedDesk != 0)
            {
                this.allDesks[this.selectedDesk - 1].Release();
            }
        }
        public void Print()
        {
            Console.WriteLine($"Room {this.Name}\n");
        }
        public void DeleteDesk()
        {
            Console.WriteLine("*** Delete Desk ***");
            this.PrintAllDesks();

            if (this.allDesks.Count > 0)
            {
                SelectDesk();
                
                if (this.selectedDesk != 0)
                {
                    this.allDesks.RemoveAt(this.selectedDesk - 1);
                    Console.WriteLine("Desk has been deleted");
                }
            }
            else
            {
                Console.WriteLine("There are no desks in this room");
            }
        }
        public void AddDesk()
        {
            Console.WriteLine("*** Add Desk ***");

            if (this.allDesks.Count < maxNumberOfDesks)
            {
                Console.WriteLine("Do you want to add a regular desk or a hot desk?");
                Console.WriteLine("1 - Desk");
                Console.WriteLine("2 - Hot desk");

                char deskType = Console.ReadKey().KeyChar;

                switch (deskType)
                {
                    case '1':
                        this.allDesks.Add(new Desk(number: this.allDesks.Count + 1));
                        Console.WriteLine("\nDesk has been added");
                        break;
                    case '2':
                        this.allDesks.Add(new HotDesk(number: this.allDesks.Count + 1));
                        Console.WriteLine("\nHot desk has been added");
                        break;
                    default:
                        Console.WriteLine("\nInvalid selection");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No more desks can be added");
            }
        }
        private void ResetSelectedDesk()
        {
            this.selectedDesk = 0;
        }
    }
}
