using System;

namespace mini_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("            VEHICLE RENTAL SYSTEM");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("1. Processing Rental Order...");
            Console.WriteLine("--------------------------------------------------");

            Customers customer = new Customers("Fathi El-Sheikh"); 
            Vehicles vehicle = new Vehicles("Mercedes G-Class (SUV)", 300.00m); 
            int rentalDays = 5;

            Console.WriteLine($"[Vehicle Details] : {vehicle.Brand}");
            Console.WriteLine($"[Daily Rate]     : ${vehicle.DailyRate} / day");
            Console.WriteLine($"[Rental Duration] : {rentalDays} Days");
            Console.WriteLine($"[Customer Name]   : {customer.Name} (VIP Customer)");
            Console.WriteLine();

            Console.WriteLine("2. Calculating Pricing & Discounts...");
            Console.WriteLine("--------------------------------------------------");

            IPricingStrategy discountStrategy = new VipDiscount();
            PricingCalculator calculator = new PricingCalculator(discountStrategy);
            var pricing = calculator.Calculate(vehicle.DailyRate, rentalDays);

            Console.WriteLine($"[Base Total]     : ${pricing.baseTotal:N2}");
            Console.WriteLine($"[Applied Discount]: {discountStrategy.GetDiscountDescription()}");
            Console.WriteLine($"[Discount Value]  : -${pricing.discountValue:N2}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"[FINAL TOTAL]     : ${pricing.finalTotal:N2}");
            Console.WriteLine();

            Console.WriteLine("3. Executing Core Operations (SOLID Architecture)...");
            Console.WriteLine("--------------------------------------------------");

            IRentalRepository repository = new RentalRepository();
            INotificationService notificationService = new ConsoleNotificationService();
            RentalManager rentalManager = new RentalManager();

            RentalService rentalService = new RentalService(
                repository,
                notificationService,
                rentalManager,
                discountStrategy
            );

            rentalService.RentVehicle(customer, vehicle, rentalDays);

            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("      BOOKING COMPLETED SUCCESSFULLY!");
            Console.WriteLine("==================================================");

            Console.ReadKey();
        }
    }
}