using System;
using System.Collections.Generic;
using System.Text;

namespace mini_project
{
    public class RentalManager
    {
        public RentalBooking CreateBooking(Customers customer, Vehicles vehicle, int rentalDays)
        {
            if (customer == null || vehicle == null || rentalDays <= 0)
                return null;

            return new RentalBooking(customer, vehicle, rentalDays);
        }
    }
}
