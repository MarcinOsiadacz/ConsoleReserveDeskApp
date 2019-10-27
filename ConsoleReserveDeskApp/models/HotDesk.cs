using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class HotDesk : Furniture
    {
        // This list holds current reservations for HotDesk object
        private List<Reservation> currentReservations = new List<Reservation>();
        private Reservation selectedReservation;

        public HotDesk(int number = 0)
        {
            this.number = number;
        }
        private bool SelectReservation()
        {
            bool state = false;

            Console.WriteLine("Please enter start time (yyyy-MM-dd hh:mm): ");
            string startTime = Console.ReadLine();

            Console.WriteLine("Please enter end time (yyyy-MM-dd hh:mm): ");
            string endTime = Console.ReadLine();

            DateTime tmpStartTime, tmpEndTime;

            if (DateTime.TryParse(startTime, out tmpStartTime) && DateTime.TryParse(endTime, out tmpEndTime))
            {
                this.selectedReservation = new Reservation(tmpStartTime, tmpEndTime);
                state = true;
            }

            return state;
        }
        public override void Reserve()
        {   
            if (!this.SelectReservation()) { Console.WriteLine("Incorrect reservation data format"); }
            else
            {
                if (!this.IsReservationValid()) { Console.WriteLine("The HotDesk reservation cannot be made"); }
                else
                {
                    Console.WriteLine("Please enter a first name: ");
                    this.selectedReservation.User.FirstName = Console.ReadLine();

                    Console.WriteLine("Please enter a last name: ");
                    this.selectedReservation.User.LastName = Console.ReadLine();

                    this.currentReservations.Add(this.selectedReservation);

                    Console.WriteLine($"The HotDesk {this.number}. has been reserved from {this.selectedReservation.StartTime} to {this.selectedReservation.EndTime} for {this.selectedReservation.User.FirstName} {this.selectedReservation.User.LastName}");
                }
            }
        }
        public override void Release()
        {
            // to be implemented
        }
        public override void Print()
        {
            if (this.currentReservations.Count > 0)
            {
                Console.WriteLine($"Hot Desk { this.number} - current reservations:");
                foreach (Reservation reservation in this.currentReservations)
                {
                    Console.WriteLine(
                    $"\t{reservation.StartTime} to {reservation.EndTime} " +
                    $"by {reservation.User.FirstName} {reservation.User.LastName}");
                } 
            }
            else { Console.WriteLine($"Hot Desk {this.number} - available"); }
        }
        public bool IsReservationValid()
        {   // Returns true if the reservation is valid and can be made. False otherwise.

            bool isValid = true;

            // Reservation is invalid if it ends before it begins
            if (DateTime.Compare(this.selectedReservation.StartTime, this.selectedReservation.EndTime) == 1)
            {
                isValid = false;
            }
            // Else if there are any reservations for this desk
            else if (this.currentReservations.Count > 0)
            {
                // Compare pending reservation with all current reservations for this desk
                foreach (Reservation currentReservation in this.currentReservations)
                {
                    // Reservation is invalid if it begins during another reservation
                    if (DateTime.Compare(this.selectedReservation.StartTime, currentReservation.StartTime) == 1 
                        && DateTime.Compare(this.selectedReservation.StartTime, currentReservation.EndTime) == -1)
                    {
                        isValid = false;
                        break;
                    }
                    // Reservation is invalid if it ends during another reservation
                    else if (DateTime.Compare(this.selectedReservation.EndTime, currentReservation.StartTime) == 1 
                        && DateTime.Compare(this.selectedReservation.EndTime, currentReservation.EndTime) == -1)
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }
    }
}
