using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    interface IReservationManagement
    {
        void AddReservation();
        void DeleteReservation();
        void CheckReservation();
    }
}
