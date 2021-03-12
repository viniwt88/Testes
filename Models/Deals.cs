using System;
using System.Collections.Generic;
using System.Text;

namespace TestesConsole.Models
{
    public class Deal
    {
        public long Id { get; internal set; }
        public decimal PriceOver { get; internal set; }
        public decimal DiscountPercentage { get; internal set; }
    }

    public static class Deals
    {
        public static List<Deal> DealsList { get; set; } = new List<Deal>
        {
            new Deal { Id = 1, PriceOver = 20, DiscountPercentage = 0.05M },
            new Deal { Id = 2, PriceOver = 50, DiscountPercentage = 0.075M },
            new Deal { Id = 3, PriceOver = 100, DiscountPercentage = 0.1M },
            new Deal { Id = 4, PriceOver = 200, DiscountPercentage = 0.15M },
            new Deal { Id = 5, PriceOver = 500, DiscountPercentage = 0.175M },
            new Deal { Id = 6, PriceOver = 1000, DiscountPercentage = 0.2M }
        };
    }
}
