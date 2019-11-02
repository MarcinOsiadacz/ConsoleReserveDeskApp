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
        private const int MaxNumberOfDesks = 20;
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

            for (int i = 0; i < MaxNumberOfDesks; i++)
            {   // Desk objects are created for the first half of the list
                if (i < (MaxNumberOfDesks/2)) { this.allDesks.Add(new Desk(number: i + 1)); }
                // and HotDesk objects for the second one.
                else { this.allDesks.Add(new HotDesk(number: i + 1)); }  
            }
        }
        public void PrintAllDesks()
        {
            foreach (Equipment desk in this.allDesks) { desk.Print(); }

            Console.WriteLine($"Total desks: {MaxNumberOfDesks}\n");
        }
        public void PrintAvailableDesks()
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
        public void PrintReservedDesks()
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

                if(this.selectedDesk < 0 || this.selectedDesk > MaxNumberOfDesks)
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

            if (this.selectedDesk != 0) { this.allDesks[this.selectedDesk - 1].Release(); }
        }
        public void Print()
        {
            Console.WriteLine($"Room {this.Name}\n");
        }
        private void ResetSelectedDesk()
        {
            this.selectedDesk = 0;
        }
    }
}
