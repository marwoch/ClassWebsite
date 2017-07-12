using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Please enter your desired username")]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }
}