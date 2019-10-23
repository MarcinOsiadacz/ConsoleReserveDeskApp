using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    abstract class Furniture : IReservation
    {
        protected int number;

        public abstract void Reserve();
        public abstract void Release();
        public abstract void Print();
    }
}
