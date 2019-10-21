using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Building : IReservation
    {
        private const int maxNumberOfRooms = 3;
        private int currentNumberOfRooms;
        private List<Room> allRooms = new List<Room>();

        private int selectedRoom;

        public Building(int currentNumberOfRooms = 0, int selectedRoom = 0)
        {
            this.currentNumberOfRooms = currentNumberOfRooms;
            this.selectedRoom = selectedRoom;
        }
        public void PrintAllDesks()
        {
            foreach (Room room in this.allRooms)
            {
                room.Print();
                room.PrintAllDesks();
            }
        }
        public void PrintAvailableDesks()
        {
            foreach (Room room in this.allRooms)
            {
                room.Print();
                room.PrintAvailableDesks();
            }
        }
        public void PrintReservedDesks()
        {
            foreach (Room room in this.allRooms)
            {
                room.Print();
                room.PrintReservedDesks();
            }
        }
        public void AddReservation()
        {
            Console.WriteLine("*** Add reservation ***");

            SelectRoom();

            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].AddReservation();
            }
        }

        public void DeleteReservation()
        {
            Console.WriteLine("*** Delete reservation ***");

            SelectRoom();

            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].DeleteReservation();
            }
        }
        public void CheckReservation()
        {
            Console.WriteLine("*** Check reservation ***");

            SelectRoom();

            if(this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].CheckReservation();
            }
        }
        public void AddRoom(string name)
        {
            if(this.currentNumberOfRooms < maxNumberOfRooms)
            {
                this.allRooms.Add(new Room(name));
                this.currentNumberOfRooms++;
            }
            else { Console.WriteLine("No more rooms can be added"); }
        }
        public void SelectRoom()
        {
            PrintAllRooms();

            int tmpSelectedRoom;

            Console.WriteLine("Please enter a number of the room (or 0 to quit): ");
            string strRoom = Console.ReadLine();

            if (!Int32.TryParse(strRoom, out tmpSelectedRoom)) { Console.WriteLine("Invalid number"); }
            else
            {
                this.selectedRoom = tmpSelectedRoom;

                if (this.selectedRoom < 0 || this.selectedRoom > this.currentNumberOfRooms)
                {
                    if (this.selectedRoom != 0)
                    {
                        this.selectedRoom = 0;
                        Console.WriteLine("Room does not exist");
                    }
                }
            }
        }
        public void PrintAllRooms()
        {
            for(int i = 0; i < this.currentNumberOfRooms; i++)
            {
                Console.WriteLine($"Room no {i + 1}:  {this.allRooms[i].Name}");
            }

            Console.WriteLine($"Total rooms: {this.currentNumberOfRooms}");
        }
    }
}
