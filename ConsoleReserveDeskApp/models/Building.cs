using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Building : IReservationManagement
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
            if (this.allRooms.Count == 0) Console.WriteLine("No rooms available in the building");
            else
            {
                foreach (Room room in this.allRooms)
                {
                    room.Print();
                    room.PrintAllDesks();
                }
            }
        }
        public void PrintAvailableDesks()
        {
            if (this.allRooms.Count == 0) Console.WriteLine("No rooms available in the building");
            else
            {
                foreach (Room room in this.allRooms)
                {
                    room.Print();
                    room.PrintAvailableDesks();
                }
            }
        }
        public void PrintReservedDesks()
        {
            if (this.allRooms.Count == 0) Console.WriteLine("No rooms available in the building");
            else
            {
                foreach (Room room in this.allRooms)
                {
                    room.Print();
                    room.PrintReservedDesks();
                }
            }
        }
        public void AddReservation()
        {
            Console.WriteLine("*** Add reservation ***\n");

            SelectRoom();
            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].AddReservation();
            }
        }
        public void DeleteReservation()
        {
            Console.WriteLine("*** Delete reservation ***\n");

            SelectRoom();
            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].DeleteReservation();
            }
        }
        public void CheckReservation()
        {
            Console.WriteLine("*** Check reservation ***\n");

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
                Console.WriteLine($"Room {name} has been added to the building");
            }
            else Console.WriteLine("No more rooms can be added");
        }
        public void DeleteRoom()
        {
            Console.WriteLine("*** Delete room ***\n");

            SelectRoom();
            if(this.selectedRoom != 0)
            {
                if (this.allRooms.Count > 0)
                {
                    Console.WriteLine("*** Delete room ***\n");
                    this.allRooms.RemoveAt(this.selectedRoom - 1);
                    this.currentNumberOfRooms--;
                    Console.WriteLine("Room has been deleted");
                }
                else Console.WriteLine("There are no rooms to delete");
            }  
        }
        public void ReadRoom()
        {
            Console.WriteLine("*** Add room ***\n");

            Console.WriteLine("Enter room name: ");
            string roomName = Console.ReadLine();
            this.AddRoom(roomName);
        }
        public void AddDesk()
        {
            Console.WriteLine("*** Add desk ***\n");

            SelectRoom();
            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].AddDesk();
            }
        }
        public void DeleteDesk()
        {
            Console.WriteLine("*** Delete desk ***\n");

            SelectRoom();
            if (this.selectedRoom != 0)
            {
                this.allRooms[this.selectedRoom - 1].DeleteDesk();
            }
        }
        public void SelectRoom()
        {
            PrintAllRooms();
            if (this.allRooms.Count > 0)
            {   
                int tmpSelectedRoom;

                Console.WriteLine("Please enter a number of the room (or 0 to quit): ");
                string strRoom = Console.ReadLine();

                if (!Int32.TryParse(strRoom, out tmpSelectedRoom)) Console.WriteLine("Invalid number");
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
        }
        public void PrintAllRooms()
        {
            if (this.allRooms.Count == 0) Console.WriteLine("No rooms available in the building");
            else
            {
                for (int i = 0; i < this.currentNumberOfRooms; i++)
                {
                    Console.WriteLine($"{i + 1}. {this.allRooms[i].Name}");
                }
                Console.WriteLine($"Total rooms: {this.currentNumberOfRooms}\n");
            }
        }
    }
}
