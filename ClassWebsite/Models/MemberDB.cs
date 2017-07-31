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

        /// <summary>
        /// finds a member with the supplied credentials
        /// Returns null if there is no match
        /// </summary>
        /// <param name="username"> member user name </param>
        /// <param name="password"> member password </param>
        /// <returns></returns>
        public static Member FindMember(string username, string password)
        {
            var db = new ECommerceDB();
            //finds user with supplied credentials
            Member m = (from mem in db.Members
                        where mem.UserName == username
                        && mem.Password == password
                        select mem).SingleOrDefault();
            return m;
        }

        public static Member GetCurrentMember()
        {
            int id = SessionHelper.GetCurrentUserID();
            ECommerceDB db = new ECommerceDB();

            Member mem = (from m in db.Members
                          where m.MemberID == id
                          select m).Single();
            return mem;
        }
    }
}