using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class Product
    {
        public int productID { get; set; }
        [DisplayName("Product Name")]

        public string productName { get; set; }
        [DisplayName("Product Size")]

        public string productSize  { get; set; }
        [DisplayName("Description")]

        public string description  { get; set; }
        [DisplayName("Price")]

        public decimal Price { get; set; }
        [DisplayName("Category ID")]


        public int categoryID  { get; set; }
        [DisplayName("Brand")]

        public string brand { get; set; }
        [DisplayName("Stock Quantity")]

        public string stockQuantity  { get; set; }
        [DisplayName("Image")]

        public byte[] image { get; set; }
        [DisplayName("Product Source")]

        public string productSource  { get; set; }
        [DisplayName("SellerID")]

        public int sellerID { get; set; }

       
    }
    public class CartItem
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal Price { get; set; }

        public int stockQuantity { get; set; }

        // Other properties...
    }
}