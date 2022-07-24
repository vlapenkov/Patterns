using DesignPatternsInCSharp.RulesEngine.Discounts;
using System;

namespace Rules
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer { DateOfBirth = new DateTime(1990, 1, 1), DateOfFirstPurchase = DateTime.Now };

            var result = new DiscountCalculator().CalculateDiscountPercentage(customer);

            Console.ReadKey();
        }
    }
}
