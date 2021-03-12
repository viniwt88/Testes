using System.Collections.Generic;
using System.Linq;
using TestesConsole.Models;

namespace TestesConsole.Business
{
    public static class ProductBusiness
    {
        public delegate void ApplyDeal(decimal subTotal);

        public static decimal CalculateTotal(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price) * (1 - CalculateDiscount(products.Sum(p => p.Price)));
        }

        public static decimal CalculateDiscount(decimal sum)
        {
            return Deals.DealsList.First(p => p.PriceOver > sum)?.DiscountPercentage ?? 0;
        }

    }
}
