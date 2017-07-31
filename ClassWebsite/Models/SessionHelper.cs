using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public static class SessionHelper
    {
        // logs member in
        public static void LogUserIn(Member m)
        {
            HttpContext.Current.Session["MemberID"] = m.MemberID;
        }

        // checks if user is logged in
        public static bool IsUserLoggedIn()
        {
            if (HttpContext.Current.Session["MemberID"] == null)
            {
                return false;
            }
            return true;
        }

        // gets current user
        public static int GetCurrentUserID()
        {
            return (int)HttpContext.Current.Session["MemberID"];
        }
    }
}