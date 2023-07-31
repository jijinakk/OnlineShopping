using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string productSize { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int categoryID { get; set; }
        public string brand { get; set; }
        public int stockQuantity { get; set; }
        public string imageURL { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public string productSource { get; set; }
        public Nullable<int> sellerID { get; set; }
    }
}