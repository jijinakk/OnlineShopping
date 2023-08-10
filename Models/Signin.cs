using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Web;

namespace OnlineShopping.Models
{
    public class Signin
    {
        public int id { get; set; }

        [DisplayName("Username")]

        public string username { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]

        public string password { get; set; }

        public string usertype { get; set; }
    }
}
