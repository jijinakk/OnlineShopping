using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OnlineShopping.Respository
{
    public class UserRespository
    {
        private SqlConnection connection;


        private void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            connection = new SqlConnection(conString);
        }
        public List<Product> GetProductsForUser() ///int formId
        {
            List<Product> ProductList = new List<Product>();

            Connection(); // Make sure this method opens the connection

            using (SqlCommand command = new SqlCommand("sp_GetProductDetails", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open(); // Open the connection before executing the command

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Your existing code to read and populate the ApplicationForm object
                        // ...
                        Product products = new Product
                        {
                            productID = reader["productID"] != DBNull.Value ? Convert.ToInt32(reader["productID"]) : 0,
                            productName = reader["productName"] != DBNull.Value ? Convert.ToString(reader["productName"]) : string.Empty,
                            productSize = reader["productSize"] != DBNull.Value ? Convert.ToString(reader["productSize"]) : string.Empty,
                            description = reader["description"] != DBNull.Value ? Convert.ToString(reader["description"]) : string.Empty,
                            Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0,
                            categoryID = reader["categoryID"] != DBNull.Value ? Convert.ToInt32(reader["categoryID"]) : 0,
                            brand = reader["brand"] != DBNull.Value ? Convert.ToString(reader["brand"]) : string.Empty,
                            stockQuantity = reader["stockQuantity"] != DBNull.Value ? Convert.ToString(reader["stockQuantity"]) : string.Empty,
                            image = reader["image"] != DBNull.Value ? reader["image"] as byte[] : null,

                            productSource = reader["productSource"] != DBNull.Value ? Convert.ToString(reader["productSource"]) : string.Empty,
                            sellerID = reader["sellerID"] != DBNull.Value ? Convert.ToInt32(reader["sellerID"]) : 0,

                        };
                        ProductList.Add(products);
                    }
                }
            }

            // Don't forget to close the connection after reading data
            connection.Close();

            return ProductList;
        }


    }
}