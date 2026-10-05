using System;
using System.Collections.Generic;
using System.Text;

namespace mini_project
{
    public class Customers
    {
        public string Name { get; set; }

        public Customers(string name)
        {
            Name = name;
        }
    }

    public class Vehicles
    {
        public string Brand { get; set; }
        public decimal DailyRate { get; set; }

        public Vehicles(string brand, decimal dailyRate)
        {
            Brand = brand;
            DailyRate = dailyRate;
        }
    }
}
