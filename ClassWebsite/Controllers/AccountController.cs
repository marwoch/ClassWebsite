using ClassWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel mem)
        {
            // make sure model is valid
            if (ModelState.IsValid)
            {
                //map values
                Member m = new Member()
                {
                    UserName = mem.Username,
                    Password = mem.Password,
                    Email = mem.Email,
                };
                //if valid add to database
                MemberDB.RegisterMember(m);
                return RedirectToAction("Index", "Home");
            }
            //if invalid return view with errors
            return View(mem);
        }
    }
}