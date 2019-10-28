using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Furniture : IReservation
    {
        // If the number value is 0, there is no assigned desk. In this case, the desk does not physically exist,
        // so it should not be possible to reserve it.
        protected int number;

        public Furniture() { }
        public virtual bool IsReserved() { return false; }
        public virtual void Reserve() { }
        public virtual void Release() { }
        public virtual void Print() { }
    }
}
