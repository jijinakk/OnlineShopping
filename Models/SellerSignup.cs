using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Drawing;

namespace OnlineShopping.Models
{
    public class SellerSignup
    {
        public int id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public char gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("PhoneNumber")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "enter  your valid id Proof number")]
        [DisplayName("Id Number")]
        public string idNumber { get; set; }



        [Required(ErrorMessage = "Select the city")]
        [DisplayName("City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Select the state")]
        [DisplayName("State")]
        public string state { get; set; }
        
        [Required(ErrorMessage = "Select the country")]
        [DisplayName("Country")]
        public string country { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]

        public string password { get; set; }
        [Required(ErrorMessage = "Re-enter the password")]
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]

        public string confirmPassword { get; set; }

        public string usertype { get; set; } = "customer"; // Default value set here

    }
}