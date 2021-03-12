using System.Collections.Generic;

namespace TestesConsole.Models
{
    public class ShoppingCart
    {
        public long Id { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public Client Client { get; set; }

    }
}
