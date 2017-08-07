using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ServerProblem()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}