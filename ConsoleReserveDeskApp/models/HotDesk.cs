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

        public HotDesk(int number = 0)
        {
            this.number = number;
        }
        public override void Reserve()
        {
            // to be implemented
        }
        public override void Release()
        {
            // to be implemented
        }
        public override void Print()
        {
            // to be implemented
        }
        public bool IsReservationValid(Reservation pendingReservation)
        {
            bool status = true;

            if (this.currentReservations.Count > 0)
            {
                foreach (Reservation currentReservation in this.currentReservations)
                {
                    if (DateTime.Compare(pendingReservation.StartTime, currentReservation.StartTime) == 1 &&
                        DateTime.Compare(pendingReservation.StartTime, currentReservation.EndTime) == -1)
                    {

                    }
                }
            }
            return false;
        }
    }
}
