using System.Collections.Generic;
using website.DomainEntities;

namespace website.Models
{
    public class ShoppingListModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}