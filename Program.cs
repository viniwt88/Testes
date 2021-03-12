using System;
using System.Collections.Generic;
using System.Linq;
using TestesConsole.Business;
using TestesConsole.Models;

namespace TestesConsole
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var clients = Mocker.Mocker<Client>.Mock() as List<Client>;
            var products = Mocker.Mocker<Product>.Mock() as List<Product>;
            var shoppingCart = Mocker.Mocker<ShoppingCart>.Mock(clients, products, 10) as ShoppingCart;

            var soma = shoppingCart.Products.Sum(p => p.Price);

            var somaDesconto = ProductBusiness.CalculateTotal(shoppingCart.Products);
            var somaDescontoDelegado = ProductBusiness.CalculateTotal(shoppingCart.Products);
        }
    }
}
