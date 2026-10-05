using System;
using System.Collections.Generic;
using System.Text;

namespace mini_project
{
    public class RentalBooking
    {
        public Customers Customer { get; set; }
        public Vehicles Car { get; set; }
        public int RentalDays { get; set; }
        public decimal BaseTotal { get; set; }
        public decimal FinalTotal { get; set; }

        public RentalBooking(Customers customer, Vehicles car, int rentalDays)
        {
            Customer = customer;
            Car = car;
            RentalDays = rentalDays;
        }
    }
}