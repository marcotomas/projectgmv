using System;
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

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void Add(Product prod)
        {
            Products.Add(prod);
        }

        public void Remove(int prodId)
        {
            Product p = Products.SingleOrDefault(x => x.Id == prodId);
            if (p != null)
                Products.Remove(p);
            else
                throw new Exception("Product not found");
        }
    }
}