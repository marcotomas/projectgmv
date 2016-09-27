using System.Collections.Generic;
using website.DomainEntities;

namespace website.Models
{
    public class ShoppingListModel
    {
        public string Name { get; set; }

        public List<DomainEntities.Product> Products { get; set; }

        public List<DomainEntities.ShoppingList> ShopList { get; set; }
    }
}