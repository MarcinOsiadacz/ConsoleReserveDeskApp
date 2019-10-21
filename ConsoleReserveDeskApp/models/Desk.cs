using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Desk : Furniture
    {
        // If the number value is 0, there is no assigned desk. In this case, the desk does not physically exist,
        // so it should not be possible to reserve it.
        private int number;

        public Desk(string userFirstName = "", string userLastName = "", int number = 0, bool isReserved = false)
        {
            this.assignedUser = new User(userFirstName, userLastName);
            this.number = number;
            this.IsReserved = isReserved;
        }
        public override void Reserve()
        {
            if (IsReserved) { Console.WriteLine("The desk is already reserved"); }
            else
            {
                Console.WriteLine("Please enter a first name: ");
                this.assignedUser.FirstName = Console.ReadLine();

                Console.WriteLine("Please enter a last name: ");
                this.assignedUser.LastName = Console.ReadLine();

                IsReserved = true;

                Console.WriteLine(
                    $"The desk {this.number}. has been reserved for {assignedUser.FirstName} {assignedUser.LastName}");
            }
        }
        public override void Release()
        {
            if (IsReserved)
            {
                this.assignedUser.FirstName = "";
                this.assignedUser.LastName = "";

                this.IsReserved = false;

                Console.WriteLine("Reservation has been deleted");
            }
            else { Console.WriteLine("Reservation does not exist"); }
        }
        public override void Print()
        {
            if(IsReserved)
            {
                Console.WriteLine(
                    $"Desk {this.number} - reserved by {this.assignedUser.FirstName} {this.assignedUser.LastName}");
            }
            else { Console.WriteLine($"Desk {this.number} - available"); }
        }
    }
}
