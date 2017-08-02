using ClassWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //int page = 0;
            //if (id.HasValue)
            //{
            //    page = id.Value;
            //}
            //else
            //{
            //    page = 1;
            //}
            int currPage = (id.HasValue) ? id.Value : 1; //ternary operator/conditional operator... condition ? thing1 : THING2
            const int PRODS_PER_PAGE = 2;

            ECommerceDB db = new ECommerceDB();
            List<Product> prods =
                db.Products
                .OrderBy(p => p.Name)
                .Skip((currPage - 1) * PRODS_PER_PAGE)
                .Take(PRODS_PER_PAGE)
                .ToList();

            //prevents integer division & rounds up to the next whole number
            ViewBag.MaxPage = Math.Ceiling(db.Products.Count() / (double)PRODS_PER_PAGE); // make sure it rounds up to the next whole number

            ViewBag.CurrentPage = currPage;

            return View(prods);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase prodPhoto)
        {
            //alternate way of getting file upload
            //httpPostedFileBase my file = 
            // Request.Files["prodPhoto"]
            if (ModelState.IsValid)
            {
                if (prodPhoto != null && prodPhoto.ContentLength > 0)
                {
                    //check the MIME type

                    //creates unique file name to prevent being overwritten
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(prodPhoto.FileName);

                    //generates a path with the file name appended
                    string path = Path.Combine(Server.MapPath("~/Images"), fileName);

                    prodPhoto.SaveAs(path);
                    p.PhotoLocation = fileName;
                }
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