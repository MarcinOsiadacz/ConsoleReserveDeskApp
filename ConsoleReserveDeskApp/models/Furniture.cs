using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Furniture : IReservation
    {
        protected int number;

        public Furniture() { }
        public virtual bool IsReserved() { return false; }
        public virtual void Reserve() { }
        public virtual void Release() { }
        public virtual void Print() { }
    }
}
