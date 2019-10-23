using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Reservation
    {
        private User user;
        private DateTime startTime;
        private DateTime endTime;

        public Reservation(string userFirstName, string userLastName, DateTime startTime, DateTime endTime)
        {
            this.User = new User(userFirstName, userLastName);
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public User User { get => user; set => user = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
    }
}
