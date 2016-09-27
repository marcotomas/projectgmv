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
            List<DomainEntities.ShoppingList> list = new List<DomainEntities.ShoppingList>();
            using (var context = new websiteEntities())
            {
                int c = context.ShoppingList.Count();
                var dbList = context.ShoppingList.ToList();
                foreach (var item in dbList)
                {
                    list.Add(new DomainEntities.ShoppingList(item.name) { Id = item.id });
                }
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
                var element = context.ShoppingList.FirstOrDefault(x => x.name == list.Name);

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

        public static List<DomainEntities.Product> AllProductList()
        {
            List<DomainEntities.Product> list = new List<DomainEntities.Product>();
            using (var context = new websiteEntities())
            {
                int c = context.Product.Count();
                var dbList = context.Product.ToList();
                foreach (var item in dbList)
                {
                    list.Add(new DomainEntities.Product(item.name) { Id = item.id });
                }
            }

            return list;
        }

        public static void InserProductList(DomainEntities.Product prod, int idListShop)
        {

            using (var context = new websiteEntities())
            {
                ListProducts list = new ListProducts()
                {
                    prodId = prod.Id,
                    shopId = idListShop
                };

                context.ListProducts.Add(list);
                context.SaveChanges();
            }
        }

    }
}