using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using OnlineShopping.Models;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using OnlineShopping.Respository;

namespace OnlineShopping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase file)

        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand command = new SqlCommand("[dbo].[sp_InsertProduct]", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@productName", product.productName);
                command.Parameters.AddWithValue("@productSize", product.productSize);
                command.Parameters.AddWithValue("@description", product.description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@categoryID", product.categoryID);
                command.Parameters.AddWithValue("@brand", product.brand);
                if (file != null)
                {
                    // Read the file data into a byte array
                    byte[] image;
                    using (BinaryReader reader = new BinaryReader(file.InputStream))
                    {
                        image = reader.ReadBytes(file.ContentLength);
                    }

                    // Save the image data as varbinary in the database
                    command.Parameters.AddWithValue("@image", image);
                }
                command.Parameters.AddWithValue("@stockQuantity", product.stockQuantity);

                command.Parameters.AddWithValue("@productSource", product.productSource);
                command.Parameters.AddWithValue("@sellerID", product.sellerID);

                command.ExecuteNonQuery();
                connection.Close();
                ViewData["Message"] = "product added" + product.productName + "saved";
                return RedirectToAction("AdminHomePage","Admin");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult GetProducts()
        {
            ProductRespository productRespository = new ProductRespository();
            List<Product> allproduct = productRespository.GetProducts();
            ModelState.Clear();
            return View(allproduct);

        }
        public ActionResult GetProductForUser()
        {
            UserRespository userRespository = new UserRespository();
            List<Product> allproduct = userRespository.GetProductsForUser();
            ModelState.Clear();
            return View(allproduct);

        }
        [HttpPost]
        public JsonResult AddToCart(int productID)
        {

            ProductRespository productRespository = new ProductRespository();
            try
            {
                List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;
                if (cartItems == null)
                {
                    cartItems = new List<CartItem>();
                }

                CartItem existingCartItem = cartItems.FirstOrDefault(item => item.productID == productID);
                if (existingCartItem != null)
                {
                    existingCartItem.stockQuantity++;
                }
                else
                {
                    Product product = productRespository.GetProductById(productID);
                    if (product != null)
                    {
                        cartItems.Add(new CartItem
                        {
                            productID = product.productID,
                            image=product.image,
                            productName = product.productName,
                            Price = product.Price,
                            stockQuantity = 1
                        });
                    }
                }
                Session["CartItems"] = cartItems;


                var response = new { success = true, cartItemCount = cartItems.Count };
                return Json(response);
            }
            
            catch (Exception )
            {
                return Json(new { success = false, errorMessage = "An error occurred while adding the product to cart." });
            }
        }

        [HttpGet]
        
        public ActionResult CartItems()
        {
            // Retrieve cart items from your data source (session, database, etc.)
            List<CartItem> cartItems = GetCartItemsFromDataSource();

            return View(cartItems);
        }
        private List<CartItem> GetCartItemsFromDataSource()
        {
            // Retrieve cart items from session
            List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;

            // If cartItems is null, initialize an empty list
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
            }

            return cartItems;
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<CartItem> sessionCartItems = Session["CartItems"] as List<CartItem>;
            if (sessionCartItems != null)
            {
                var itemToRemove = sessionCartItems.FirstOrDefault(item => item.productID == id);
                if (itemToRemove != null)
                {
                    sessionCartItems.Remove(itemToRemove);
                    Session["CartItems"] = sessionCartItems;
                }
            }

            return RedirectToAction("CartItems");
        }


        public ActionResult UpdateProduct(int? id)
        {
            ProductRespository productRespository = new ProductRespository();
            return View(productRespository.GetProducts().Find(sign => sign.productID == id));

        }

        [HttpPost]
        public ActionResult UpdateProduct( int? id,Product product, HttpPostedFileBase newImage)
        {
            ProductRespository productRespository = new ProductRespository();
            if (newImage != null)
            {
                byte[] imageData;
                using (Stream inputStream = newImage.InputStream)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }

                product.image = imageData;
            }
           productRespository.UpdateProduct(product);
            return RedirectToAction("AddProduct");

            // Redirect or return a view
        }

        public ActionResult DeleteProduct(int productID, Product product)
        {
            try
            {
                ProductRespository productRespository = new ProductRespository();
                if (productRespository.DeleteProduct(productID))
                {
                    ViewBag.AlertMessage("User details deleted successfully");
                }
                return RedirectToAction("GetProducts");
            }
            catch
            {
                return View();
            }
        }
    }
}