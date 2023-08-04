using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class Contactus
    {
        [DisplayName("Name")]

        public string name { get; set; }
        [DisplayName("Email")]

        public string email { get; set; }
        [DisplayName("Subject")]

        public string subject { get; set; }
        [DisplayName("Message")]

        public string message { get; set; }

    }
}