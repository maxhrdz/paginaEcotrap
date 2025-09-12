using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiscountCodes.Models
{
    public class ShoppingCart
    { 
        private readonly List<Product> _items = new();

        
            public ReadOnlyCollection<Product> Items => _items.AsReadOnly();
         public void AddItem(Product product)
        {
            _items.Add(product);
        }

        
        public decimal GetTotal() => Math.Round(_items.Sum(p => p.Price), 2);

        
        public decimal ApplyDiscount(string? code)
        {
            var subtotal = GetTotal();
            if (subtotal <= 0 || string.IsNullOrWhiteSpace(code))
                return subtotal;

            code = code.Trim().ToUpperInvariant();
            decimal discount = code switch
            {
                "BOGOFREE"       => BogoDiscount(),
                "BRAND2DISCOUNT" => SumByBrand("Brand2") * 0.10m,
                "10PERCENTOFF"   => subtotal * 0.10m,
                "BRAND1MANIA"    => SumByBrand("Brand1") * 0.50m,
                "5USDOFF"        => Math.Min(5m, subtotal),
                _                => 0m
            };

            return Math.Round(Math.Max(0, subtotal - discount), 2);
        }

        

        
        private decimal BogoDiscount()
        {
            decimal discount = 0;
            var grupos = _items.GroupBy(p => new { p.Brand, p.Name, p.Price });
            foreach (var g in grupos)
            {
                int cantidad = g.Count();
                int gratis = cantidad / 2;
                discount += gratis * g.Key.Price;
            }
            return discount;
        }

        private decimal SumByBrand(string brand) =>
            _items.Where(p => p.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                  .Sum(p => p.Price);
    }
}
