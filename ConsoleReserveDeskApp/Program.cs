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
            building.AddRoom("test1");
            building.AddRoom("test2");
            building.PrintAllRooms();

        }
    }
}
