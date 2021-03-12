using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using TestesConsole.Models;

namespace TestesConsole.Mocker
{
    public static class Mocker<T> where T : class
    {
        private static Random _random { get; set; } = new Random(Convert.ToInt32(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddssmmmm")) /
                                                                         Convert.ToInt32(DateTime.Now.ToString("mmss"))));

        public static object Mock(IEnumerable<Client> clients = null, IEnumerable<Product> products = null, int? nrOfProducts = null)
        {
            if (typeof(T).Name == "Client")
                return MockClient();
            if (typeof(T).Name == "Product")
                return MockProduct();
            if (typeof(T).Name == "ShoppingCart")
                return MockShoppingCart(clients, products, nrOfProducts ?? 0);
            return null;
        }

        private static IEnumerable<Client> MockClient()
        {
            return new List<Client>{
                new Client{Id = 1, Name = "John"},
                new Client{Id = 2, Name = "Joshua"},
                new Client{Id = 3, Name = "Joplin"},
                new Client{Id = 4, Name = "Julian"},
                new Client{Id = 5, Name = "Jarvas"},
                new Client{Id = 6, Name = "Jaspion"},
                new Client{Id = 7, Name = "Juliet"},
                new Client{Id = 8, Name = "Jenkins"},
                new Client{Id = 9, Name = "Junior"},
                new Client{Id = 10, Name = "Jill"},
                new Client{Id = 11, Name = "Julius"},
                new Client{Id = 12, Name = "Jasmine"},
                new Client{Id = 13, Name = "Jared"}
            };
        }

        private static IEnumerable<Product> MockProduct()
        {
            return new List<Product>
            {
                new Product {Id = 1000, Name = "Black KitKat", Price = 2.49M},
                new Product {Id = 1001, Name = "White KitKat", Price = 2.49M},
                new Product {Id = 1002, Name = "Coke 350ml", Price = 2.30M},
                new Product {Id = 1003, Name = "Sprite 350ml", Price = 2.19M},
                new Product {Id = 1004, Name = "Kitchen Knife", Price = 30.00M},
                new Product {Id = 1005, Name = "Fry Pan", Price = 60.00M},
                new Product {Id = 1006, Name = "Napkins", Price = 3.80M},
                new Product {Id = 1007, Name = "Pringles", Price = 8.90M},
                new Product {Id = 1008, Name = "Sugar 1kg", Price = 2.69M},
                new Product {Id = 1009, Name = "Rice 5kg", Price = 18.90M},
                new Product {Id = 1010, Name = "Porky Ribs 1kg", Price = 24.49M},
                new Product {Id = 1011, Name = "Sausage 500g", Price = 7.99M},
                new Product {Id = 1012, Name = "Orange 1kg", Price = 3.25M},
                new Product {Id = 1013, Name = "Lemon 1kg", Price = 3.99M},
                new Product {Id = 1014, Name = "Banana 1kg", Price = 2.49M},
                new Product {Id = 1015, Name = "Fuji Apple 1kg", Price = 7.15M},
                new Product {Id = 1016, Name = "Garbage Bags 5L 1 un", Price = 0.19M},
                new Product {Id = 1017, Name = "Garbage Bags 20L 1 un", Price = 0.40M},
                new Product {Id = 1018, Name = "Garbage Bags 80L 1 un", Price = 0.85M},
                new Product {Id = 1019, Name = "Bread 1 un", Price = 0.49M},
                new Product {Id = 1020, Name = "Chocolate cake", Price = 12.49M},
                new Product {Id = 1021, Name = "Vanilla cake", Price = 12.49M},
                new Product {Id = 1022, Name = "Strawberry cake", Price = 12.49M},
                new Product {Id = 1023, Name = "Baking Tray", Price = 50.00M},
                new Product {Id = 1024, Name = "Bowl size S", Price = 20.00M},
                new Product {Id = 1025, Name = "Bowl size M", Price = 30.00M},
                new Product {Id = 1026, Name = "Bowl size L", Price = 40.00M},
                new Product {Id = 1027, Name = "CupNoodles", Price = 3.79M},
                new Product {Id = 1029, Name = "Spaghetti 500g", Price = 4.00M},
                new Product {Id = 1029, Name = "Doritos XL", Price = 15.79M},
                new Product {Id = 1030, Name = "Lollipop", Price = 00.45M},
            };
        }
        private static ShoppingCart MockShoppingCart(IEnumerable<Client> clients, IEnumerable<Product> products, int nrOfProducts)
        {
            Client client = null;
            do
            {
                var clientId = RandomNumber(1, clients.Count());
                client = clients.First(c => c.Id == clientId);
            } while (client == null);

            var cartProducts = new List<Product>();

            for (int i = 0; i < nrOfProducts; i++)
            {
                Product product = null;
                do
                {
                    var id = RandomNumber(1000, 1000 + products.Count());
                    product = products.FirstOrDefault(p => p.Id == id);
                    cartProducts.Add(product);
                } while (product == null);
            }

            return new ShoppingCart
            {
                Id = 0,
                Client = client,
                Products = cartProducts
            };
        }

        private static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }


    }
}
