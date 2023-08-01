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
        public ActionResult AddProduct(Product product,HttpPostedFileBase file)

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
            command.Parameters.AddWithValue("@stockQuantity", product.stockQuantity);
            if(file!=null)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/ProductImages/"), filename);
                file.SaveAs(imgPath);

            }
            command.Parameters.AddWithValue("@image", "~/ProductImages/"+file.FileName);

            command.Parameters.AddWithValue("@productSource", product.productSource);
            command.Parameters.AddWithValue("@sellerID", product.sellerID);

            command.ExecuteNonQuery();
            connection.Close();
            ViewData["Message"] = "product added" + product.productName + "saved";
            return View();
        }

        
            public ActionResult GetDetails()
            {
            string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            SqlConnection connection = new SqlConnection(conString);
            List<Signup> SignupList = new List<Signup>();
                SqlCommand command = new SqlCommand("[dbo].[SPS_Signup]", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                data.Fill(dataTable);
                connection.Close();
                foreach (DataRow datarow in dataTable.Rows)
                {

                    SignupList.Add(
                        new Product
                        {
                            productName = Convert.ToString(datarow["productName"]),
                            productSize = Convert.ToString(datarow["productSize"]),
                            description = Convert.ToString(datarow["description"]),
                            Price = Convert.ToString(datarow["Price"]),
                            categoryID = Convert.ToInt32(datarow["categoryID"]),
                            brand = Convert.ToString(datarow["brand"]),
                            stockQuantity = Convert.ToString(datarow["stockQuantity"]),
                            sellerID = Convert.ToInt32(datarow["sellerID"])


                        });
                }
                return  View();
            }
        }
    }
}