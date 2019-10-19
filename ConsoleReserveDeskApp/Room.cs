﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReserveDeskApp
{
    class Room : IReservation
    {
        private string name;
        private const int numberOfDesks = 20;
        private List<Desk> allDesks = new List<Desk>();

        // selectedDesk field stores the number of the desk selected by user in reservation related methods.
        private int selectedDesk;

        public string Name { get => name; set => name = value; }

        public Room(string name = "")
        {
            this.Name = name;
            // Number 0 means unassigned desk.
            this.selectedDesk = 0;

            for (int i = 1; i <= numberOfDesks; i++)
            {   
                // Desks are generated starting from number 1.
                this.allDesks.Add(new Desk(number: i));
            }
        }
        public void PrintAllDesks()
        {
            foreach (Desk desk in this.allDesks)
            {
                desk.Print();
            }

            Console.WriteLine($"Total desks: {numberOfDesks}");
        }
        public void PrintAvailableDesks()
        {
            int availableDeskCounter = 0;

            foreach (Desk desk in this.allDesks)
            {
                if (!desk.IsReserved)
                {
                    desk.Print();
                    availableDeskCounter++;
                }
            }

            Console.WriteLine($"Total available desks: {availableDeskCounter}");
        }
        public void PrintReservedDesks()
        {
            int reservedDeskCounter = 0;

            foreach (Desk desk in this.allDesks)
            {
                if (desk.IsReserved)
                {
                    desk.Print();
                    reservedDeskCounter++;
                }
            }

            Console.WriteLine($"Total reserved desks: {reservedDeskCounter}");
        }
        public void AddReservation()
        {
            Console.WriteLine("Add reservation: \n");
            PrintAvailableDesks();
            SelectDesk();

            if(this.selectedDesk != 0) { this.allDesks[this.selectedDesk].AddReservation(); }
        }
        public void SelectDesk()
        {
            int tmpSelectedDesk;

            Console.WriteLine("\nPlease enter a number of the desk (or 0 to quit): ");
            string strDesk = Console.ReadLine();

            if (!Int32.TryParse(strDesk, out tmpSelectedDesk)) { Console.WriteLine("Invalid number"); }
            else
            {
                this.selectedDesk = tmpSelectedDesk;

                if(this.selectedDesk < 0 || this.selectedDesk > numberOfDesks)
                {
                    if(this.selectedDesk != 0)
                    {
                        this.selectedDesk = 0;
                        Console.WriteLine("Desk does not exist");
                    }
                }
            }
        }
        public void CheckDeskAvailability()
        {
            Console.WriteLine("Check desk availability: \n");
            SelectDesk();

            if (this.selectedDesk != 0) { this.allDesks[this.selectedDesk].Print(); }
        }
        public void DeleteReservation()
        {
            Console.WriteLine("Delete reservation: \n");
            PrintReservedDesks();
            SelectDesk();

            if (this.selectedDesk != 0) { this.allDesks[this.selectedDesk].DeleteReservation(); }
        }
        public void Print()
        {
            Console.WriteLine($"Room {this.Name}");
        }
    }
}
