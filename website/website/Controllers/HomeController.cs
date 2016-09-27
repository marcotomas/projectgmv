using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.DataLayer;
using website.Models;
namespace website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShoppingListModel model = new ShoppingListModel();
            model.ShopList = DbOperations.AllShoppingLists();
            return View(model);
        }


        [HttpPost]
        public ActionResult AddListCard(ShoppingListModel shop)
        {
            DomainEntities.ShoppingList shoppingList = new DomainEntities.ShoppingList(shop.Name);

            DbOperations.InserShopList(shoppingList);

            ShoppingListModel model = new ShoppingListModel();
            model.ShopList = DbOperations.AllShoppingLists();

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult EditListCard(string name)
        {
            ShoppingListModel model = new ShoppingListModel();
            model.Name = name;
            return PartialView("EditListShop", model);
        }

        [HttpPost]
        public ActionResult EditListCard(ShoppingListModel shop, string nameList)
        {
            DomainEntities.ShoppingList shoppingList = new DomainEntities.ShoppingList(shop.Name);
            DbOperations.UpdateNameShopList(shoppingList, nameList);
            ShoppingListModel model = new ShoppingListModel();

            model.ShopList = DbOperations.AllShoppingLists();
            return View("Index", model);
        }
        [HttpGet]
        public ActionResult RemoveListCard(string name)
        {
            ShoppingListModel model = new ShoppingListModel();
            model.Name = name;
            return PartialView("RemoveList", model);
        }

        [HttpPost]
        public ActionResult RemoveListCard(ShoppingListModel shop)
        {
            DomainEntities.ShoppingList shoppingList = new DomainEntities.ShoppingList(shop.Name);
            DbOperations.RemoveShopList(shoppingList);
            ShoppingListModel model = new ShoppingListModel();

            model.ShopList = DbOperations.AllShoppingLists();
            return View("Index", model);
        }

        public ActionResult ListItems()
        {
            ShoppingListModel model = new ShoppingListModel();
            model.Products = DbOperations.AllProductList();
            return View("listItems", model);
        }

        [HttpGet]
        public ActionResult Buy(string name)
        {
            ProductListModel model = new ProductListModel();
            model.Name = name;
            return PartialView("_confirmBuy", model);
        }

        [HttpGet]
        public ActionResult Buy(ProductListModel product, int idShopList)
        {
            DomainEntities.Product productList = new DomainEntities.Product(product.Name);
            DbOperations.InserProductList(productList, idShopList);
            ShoppingListModel model = new ShoppingListModel();
            model.Products = DbOperations.AllProductList();
            return View("listItems", model);
        }
    }
}