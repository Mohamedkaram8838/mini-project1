using System;
using System.Collections.Generic;

namespace mini_project
{
    public class RentalService
    {
        private readonly IRentalRepository repository;
        private readonly INotificationService notificationService;
        private readonly RentalManager rentalManager;
        private readonly IPricingStrategy pricingStrategy;
        public RentalService(
            IRentalRepository repository,
            INotificationService notificationService,
            RentalManager rentalManager,
            IPricingStrategy pricingStrategy) 
        {
            this.repository = repository;
            this.notificationService = notificationService;
            this.rentalManager = rentalManager;
            this.pricingStrategy = pricingStrategy;
        }

        public RentalBooking RentVehicle(
            Customers customer,
            Vehicles vehicle,
            int rentalDays)
        {
            RentalBooking booking = rentalManager.CreateBooking(
                customer,
                vehicle,
                rentalDays
            );

            if (booking == null)
            {
                notificationService.SendNotification(
                    "Vehicle is not available."
                );

                return null;
            }

            PricingCalculator calculator = new PricingCalculator(pricingStrategy);
            var pricingResult = calculator.Calculate(vehicle.DailyRate, rentalDays);

            booking.BaseTotal = pricingResult.baseTotal;
            booking.FinalTotal = pricingResult.finalTotal;

            repository.AddBooking(booking);

            string notificationMsg = $"[SMS Sent] -> Dear {customer.Name}, your {vehicle.Brand} is confirmed for {rentalDays} days. Total: ${pricingResult.finalTotal}. ({pricingResult.description})";
            notificationService.SendNotification(notificationMsg);

            return booking;
        }

        public void ShowAllBookings()
        {
            List<RentalBooking> bookings =
                repository.GetAllBookings();

            if (bookings.Count == 0)
            {
                notificationService.SendNotification(
                    "No bookings found:("
                );

                return;
            }

            foreach (RentalBooking booking in bookings)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Customer: {booking.Customer.Name}");
                Console.WriteLine($"Vehicle: {booking.Car.Brand}");
                Console.WriteLine($"Rental Days: {booking.RentalDays}");
                Console.WriteLine($"Base Total: ${booking.BaseTotal}");
                Console.WriteLine($"Final Total: ${booking.FinalTotal}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}