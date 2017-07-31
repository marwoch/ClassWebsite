using ClassWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class CartController : Controller
    {
        public ActionResult AddToCart(int id)
        {
            Product p = ProductDB.GetProductById(id);

            CartItem item = new CartItem();
            item.PriceWhenAdded = p.RetailPrice;
            item.Quantity = 1;
            item.ProductID = p.ProductID;

            var product = new HttpCookie("Cart");
            product.Value = JsonConvert.SerializeObject(item);
            product.Expires = DateTime.Now.AddYears(10);

            Response.Cookies.Add(product);
            return RedirectToAction("ViewCart", "Cart");
        }

        public ActionResult ViewCart()
        {

            //get cart items from cookie
            CartItem item = JsonConvert.DeserializeObject<CartItem>(Request.Cookies["Cart"].Value);
                                 
            return View(item);
        }

    }
}