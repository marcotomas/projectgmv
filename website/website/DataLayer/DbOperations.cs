using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace website.DataLayer
{
    public static class DbOperations
    {
        public static List<DomainEntities.ShoppingList> AllShoppingLists()
        {
            List<DomainEntities.ShoppingList> list;
            using (var context = new websiteEntities())
            {
                list = context.ShoppingList.Select(x => new DomainEntities.ShoppingList(x.name) { Id = x.id}).ToList();
            }

            return list;
        }

        public static DomainEntities.ShoppingList ShoppingListElement(string name)
        {
            DomainEntities.ShoppingList element;
            using (var context = new websiteEntities())
            {
                var elemDB = context.ShoppingList.First(x => x.name.Equals(name));
                element = new DomainEntities.ShoppingList(elemDB.name);
            }

            return element;
        }

        public static void InserShopList(DomainEntities.ShoppingList shop)
        {

            using (var context = new websiteEntities())
            {
                ShoppingList shopping = new ShoppingList()
                {
                    name = shop.Name
                };

                context.ShoppingList.Add(shopping);
                context.SaveChanges();
            }
        }

        public static void RemoveShopList(DomainEntities.ShoppingList shop)
        {

            using (var context = new websiteEntities())
            {
                var element = context.ShoppingList.FirstOrDefault(x => x.name.Equals(shop.Name));
                if (element != null)
                {
                    context.ShoppingList.Remove(element);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateNameShopList(DomainEntities.ShoppingList list, string name)
        {

            using (var context = new websiteEntities())
            {
                var element = context.ShoppingList.FirstOrDefault(x => x.id == list.Id);

                element.name = name;

                context.Entry(element).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void AddProductsList(DomainEntities.ShoppingList list, DomainEntities.Product product)
        {
            using (var context = new websiteEntities())
            {
                var elementList = context.ShoppingList.FirstOrDefault(x => x.id == list.Id);
                var dbProduct = context.Product.FirstOrDefault(x => x.id == product.Id);

                if(elementList != null && dbProduct != null)
                {
                    ListProducts listPro = new ListProducts()
                    {
                        prodId = dbProduct.id,
                        shopId = elementList.id
                    };
                    context.ListProducts.Add(listPro);
                    context.SaveChanges();
                }
            }

        }

    }
}