using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class Signup
    {
        public int id { get; set; }
        [DisplayName("First name")]
        public string firstName { get; set; }
        [DisplayName("Last name")]
        public string lastName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Future dates are not allowed.")]
        public DateTime dateOfBirth { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public char gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("PhoneNumber")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Select the city")]
        [DisplayName("City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Select the state")]
        [DisplayName("State")]
        public string state { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        [DisplayName("Pincode")]
        public int pincode { get; set; }
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

        // Other properties...
        public string usertype { get; set; } = "customer"; // Default value set here

        

    }
}