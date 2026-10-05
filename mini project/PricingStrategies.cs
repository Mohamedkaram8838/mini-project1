using System;
using System.Collections.Generic;
using System.Text;

namespace mini_project
{
    public interface IPricingStrategy
    {
        decimal CalculateDiscount(decimal baseTotal);
        string GetDiscountDescription();
    }

    public class VipDiscount : IPricingStrategy
    {
        public decimal CalculateDiscount(decimal baseTotal)
        {
            return baseTotal * 0.20m;
        }

        public string GetDiscountDescription()
        {
            return "VIP Customer Discount (20% OFF)";
        }
    }

    public class WeeklyDiscount : IPricingStrategy
    {
        public decimal CalculateDiscount(decimal baseTotal)
        {
            return baseTotal * 0.10m;
        }

        public string GetDiscountDescription()
        {
            return "Weekly Rental Discount (10% OFF)";
        }
    }

    public class NoDiscount : IPricingStrategy
    {
        public decimal CalculateDiscount(decimal baseTotal)
        {
            return 0m;
        }

        public string GetDiscountDescription()
        {
            return "No Discount Applied";
        }
    }

    public class PricingCalculator
    {
        private readonly IPricingStrategy _pricingStrategy;

        public PricingCalculator(IPricingStrategy pricingStrategy)
        {
            _pricingStrategy = pricingStrategy ?? new NoDiscount();
        }

        public (decimal baseTotal, decimal discountValue, decimal finalTotal, string description) Calculate(decimal dailyRate, int rentalDays)
        {
            decimal baseTotal = dailyRate * rentalDays;
            decimal discountValue = _pricingStrategy.CalculateDiscount(baseTotal);
            decimal finalTotal = baseTotal - discountValue;
            string description = _pricingStrategy.GetDiscountDescription();

            return (baseTotal, discountValue, finalTotal, description);
        }
    }
}
