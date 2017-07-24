using ClassWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> prods = ProductDB.GetAllProducts();

            return View(prods);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                //adds to database & send back to index
                ProductDB.AddProduct(p);
                return RedirectToAction("Index", "Product");
            }
            //return view with model errors
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //if no product id is supplied in the ur
            //user is redirected
            if (id == null)
            {
                return RedirectToAction("Index", "Product");
            }
            Product p = ProductDB.GetProductById(id.Value);

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                ProductDB.UpdateProduct(p);
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public ActionResult Delete(int? id)
        {
            //TODO: check if id is null
            if (id == null)
            {
                return RedirectToAction("Index", "Product");
            }
            ProductDB.DeleteProductById(id.Value);
            return RedirectToAction("Index");
        }
    }
}