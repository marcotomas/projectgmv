using System.Collections.Generic;
using System.Linq;

namespace website.DomainEntities
{
    public class ShoppingList
    {
        public ShoppingList(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public void Add(Product prod)
        {
            Products.Add(prod);
        }

        public void Remove(int id)
        {
            Products.Remove(Products.Single(x => x.Id == id));
        }
    }
}