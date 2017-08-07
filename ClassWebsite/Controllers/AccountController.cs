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
            if (SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel mem)
        {
            if (MemberDB.DoesUserNameExist(mem.Username))
            {
                ModelState.AddModelError("DuplicateUsername", "Somebody already has that username");
                return View(mem);
            }
            // make sure model is valid
            if (ModelState.IsValid)
            {
                //if valid add to database
                //map values object to be added
                Member m = new Member()
                {
                    UserName = mem.Username,
                    Password = mem.Password,
                    Email = mem.Email,
                };


                MemberDB.RegisterMember(m);
                SessionHelper.LogUserIn(m);

                return RedirectToAction("Index", "Home");
            }
            //if invalid return view with errors
            return View(mem);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                Member m = MemberDB.FindMember(loginData.Username, loginData.Password);
                if (m == null)//member was not found
                {
                    ModelState.AddModelError("Invalid Credentials", "No account with those credentials was found.");
                    return View(loginData);
                }
                //log in user
                SessionHelper.LogUserIn(m);

                return RedirectToAction("Index", "Home");

            }
            return View(loginData);
        }

        //[HttpGet]
        public ActionResult LogOut()
        {
            Session.Abandon();//destroy user session
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyAccount()
        {
            // if user logged in, returns their account page
            if (SessionHelper.IsUserLoggedIn())
            {
                Member currMember = MemberDB.GetCurrentMember();
                return View(currMember);
            }
            
            //if they aren't logged in, loads log in page
            return RedirectToAction("Login", "Account");
        }
    }

}