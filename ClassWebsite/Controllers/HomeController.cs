﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //throw new Exception(); // just an example
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}