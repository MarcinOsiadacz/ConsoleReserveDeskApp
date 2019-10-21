using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // dodawanie rezerwacji
            // usuwanie rezerwacji
            // sprawdzanie dostepnosci wybranego biurka
            // lista wszystkich biurek
            // lista dostepnych biurek
            // lista zarezerwowanych biurek

            Building building = new Building();
            building.AddRoom("Sala 108");
            building.AddRoom("Sala 305");
            building.AddReservation();
            building.DeleteReservation();

        }
    }
}
