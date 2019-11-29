﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class HotDesk : Equipment
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

            Console.WriteLine("Please enter start time (yyyy-MM-dd HH:mm): ");
            string startTime = Console.ReadLine();

            Console.WriteLine("Please enter end time (yyyy-MM-dd HH:mm): ");
            string endTime = Console.ReadLine();

            DateTime tmpStartTime, tmpEndTime;

            if (DateTime.TryParse(startTime, out tmpStartTime) && DateTime.TryParse(endTime, out tmpEndTime))
            {
                Console.WriteLine("Please enter a first name: ");
                string tmpFirstName = Console.ReadLine();

                Console.WriteLine("Please enter a last name: ");
                string tmpLastName = Console.ReadLine();

                this.selectedReservation = new Reservation(tmpStartTime, tmpEndTime, tmpFirstName, tmpLastName);
                state = true;
            }

            return state;
        }
        public override bool IsReserved()
        {
            if(this.currentReservations.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        public override void Reserve()
        {   
            if (!this.SelectReservation()) Console.WriteLine("Incorrect reservation data format");
            else
            {
                int isValid = this.IsReservationValid();
                if (isValid == 1)
                {
                    this.currentReservations.Add(this.selectedReservation);
                    Console.WriteLine($"The hot desk {this.number}. has been reserved from {this.selectedReservation.StartTime} to {this.selectedReservation.EndTime} for {this.selectedReservation.User.FirstName} {this.selectedReservation.User.LastName}");
                }
                else
                {
                    if (isValid == -1) Console.WriteLine("Reservation cannot end before it starts");
                    else if (isValid == -2) Console.WriteLine("Minimum reservation length is 1 hour");
                    else if (isValid == -3) Console.WriteLine("Maximum reservation length is 1 week (7 days)");
                    else if (isValid == -4) Console.WriteLine("There is already another reservation at the selected time");
                    else Console.WriteLine("Unknown error, please try again");
                }
            }
        }
        public override void Release()
        {
            if (!this.SelectReservation()) { Console.WriteLine("Incorrect reservation data format"); }
            else
            {
                // Stores the index of the selected reservation or -1 if not found.
                int reservationIndex = this.currentReservations.FindIndex(
                    reservation => reservation.StartTime == this.selectedReservation.StartTime
                    && reservation.EndTime == this.selectedReservation.EndTime
                    && reservation.User.FirstName == this.selectedReservation.User.FirstName
                    && reservation.User.LastName == this.selectedReservation.User.LastName);

                if (reservationIndex == -1) { Console.WriteLine("Reservation does not exist"); }
                else 
                {
                    this.currentReservations.RemoveAt(reservationIndex);

                    Console.WriteLine("Reservation has been deleted");
                }
            }       
        }
        public override void Print()
        {
            if (this.currentReservations.Count > 0)
            {
                Console.WriteLine($"Hot desk {this.number} - current reservations:");
                foreach (Reservation reservation in this.currentReservations)
                {
                    Console.WriteLine(
                    $"\t{reservation.StartTime} to {reservation.EndTime} " +
                    $"by {reservation.User.FirstName} {reservation.User.LastName}");
                } 
            }
            else { Console.WriteLine($"Hot desk {this.number} - available"); }
        }
        private int IsReservationValid()
        {   
            //bool isValid = true;
            int isValid = 1;

            // Reservation is invalid if it ends before it begins
            if (DateTime.Compare(this.selectedReservation.StartTime, this.selectedReservation.EndTime) == 1)
            {
                //isValid = false;
                isValid = -1;
                return isValid;
            }
            if ((this.selectedReservation.EndTime.Subtract(this.selectedReservation.StartTime).TotalHours) <= 1)
            {// reservation is shorther than 1 hour
                isValid = -2;
                return isValid;
            }
            if ((this.selectedReservation.EndTime.Subtract(this.selectedReservation.StartTime).TotalDays) >= 7)
            {// reservation is longer than one week
                isValid = -3;
                return isValid;
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
                        isValid = -4;
                        break;
                    }
                    // Reservation is invalid if it ends during another reservation
                    else if (DateTime.Compare(this.selectedReservation.EndTime, currentReservation.StartTime) == 1 
                        && DateTime.Compare(this.selectedReservation.EndTime, currentReservation.EndTime) == -1)
                    {
                        isValid = -4;
                        break;
                    }
                }
            }
            return isValid;
        }
    }
}
