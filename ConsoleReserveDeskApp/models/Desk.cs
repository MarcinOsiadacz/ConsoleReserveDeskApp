using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Desk : Equipment
    {
        private User assignedUser;
        private bool reservationStatus;
       
        public Desk(string userFirstName = "", string userLastName = "", int number = 0, bool reservationStatus = false)
        {
            this.assignedUser = new User(userFirstName, userLastName);
            this.number = number;
            this.reservationStatus = reservationStatus;
        }
        public override bool IsReserved()
        {
            return this.reservationStatus;
        }
        public override void Reserve()
        {
            if (this.reservationStatus) Console.WriteLine("The desk is already assigned");
            else
            {
                Console.WriteLine("Please enter a first name: ");
                this.assignedUser.FirstName = Console.ReadLine();

                Console.WriteLine("Please enter a last name: ");
                this.assignedUser.LastName = Console.ReadLine();

                this.reservationStatus = true;

                Console.WriteLine(
                    $"The desk {this.number}. has been assigned to {assignedUser.FirstName} {assignedUser.LastName}");
            }
        }
        public override void Release()
        {
            if (this.reservationStatus)
            {
                this.assignedUser.FirstName = "";
                this.assignedUser.LastName = "";

                this.reservationStatus = false;

                Console.WriteLine("The desk has been released");
            }
            else Console.WriteLine("Reservation does not exist");
        }
        public override void Print()
        {
            if (this.reservationStatus)
            {
                Console.WriteLine(String.Format(
                    "{0,-8} {1,-2} - assigned to {2,0} {3,0}", "Desk", this.number, this.assignedUser.FirstName, this.assignedUser.LastName));
            }
            else Console.WriteLine(String.Format("{0,-8} {1,-2} - available", "Desk", this.number));
        }
    }
}
