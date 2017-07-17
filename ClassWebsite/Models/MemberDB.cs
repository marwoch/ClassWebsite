using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public static class MemberDB
    {
        /// <summary>
        /// Adds member to the database
        /// </summary>
        /// <param name="m">member to be added</param>
        public static void RegisterMember(Member m)
        {
            ECommerceDB db = new ECommerceDB();
            db.Members.Add(m);
            db.SaveChanges(); //MUST call savechanges for  INSERT/UPDATE/DELETES
        }
    }
}