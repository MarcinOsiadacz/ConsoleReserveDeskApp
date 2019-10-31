using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    abstract class Furniture : IReservation
    {
        // If the number value is 0, there is no assigned desk. In this case, the desk does not physically exist,
        // so it should not be possible to reserve it.
        protected int number;

        public abstract bool IsReserved();
        public abstract void Reserve();
        public abstract void Release();
        public abstract void Print();
    }
}
