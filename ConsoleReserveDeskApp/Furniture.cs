using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    abstract class Furniture : IReservation
    {
        protected User assignedUser;
        protected bool isReserved;

        public bool IsReserved { get => isReserved; set => isReserved = value; }
        public abstract void Reserve();
        public abstract void Release();
        public abstract void Print();
    }
}
