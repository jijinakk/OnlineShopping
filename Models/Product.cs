using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class Product
    {

        public string productName { get; set; }
        public string productSize  { get; set; }
        public string description  { get; set; }
        public string Price { get; set; }

        public int categoryID  { get; set; }
        public string brand { get; set; }
        public string stockQuantity  { get; set; }
        public string image { get; set; }

        public string productSource  { get; set; }
        public int sellerID { get; set; }



    }
}