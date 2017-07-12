using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public class Member
    {
        public int MemberID { get; set; } //primary key

        public string UserName { get; set; } //req

        public string Password { get; set; } //req

        public DateTime? DateOfBirth { get; set; } //nullable

        public string FirstName { get; set; } //req

        public string LastName { get; set; } //null

        public string SecurityQuestion { get; set; } //req

        public string Email { get; set; } //req
    }

    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}