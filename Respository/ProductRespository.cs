using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace OnlineShopping.Respository
{
    public class ProductRespository
    {
        private SqlConnection connection;


        private void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            connection = new SqlConnection(conString);
        }
        public bool AddProduct(Product product)
        {
            Connection();
            SqlCommand command = new SqlCommand("[dbo].[sp_InsertProduct]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productName", product.productName);
            command.Parameters.AddWithValue("@productSize", product.productSize);
            command.Parameters.AddWithValue("@description", product.description);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@categoryID", product.categoryID);
            command.Parameters.AddWithValue("@brand", product.brand);
            command.Parameters.AddWithValue("@stockQuantity", product.stockQuantity);
            command.Parameters.AddWithValue("@image", product.image ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@productSource", product.productSource);
            command.Parameters.AddWithValue("@sellerID", product.sellerID);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetProducts() ///int formId
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
        public Product GetProductById(int productID)
        {
            Product product = null;

            Connection(); // Make sure this method opens the connection

            using (SqlCommand command = new SqlCommand("Sp_GetElementById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productID", productID);

                connection.Open(); // Open the connection before executing the command

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {// Your existing code to populate the Product object
                        product = new Product
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
                    }
                }
            }
            connection.Close();

            return product;
        }
        public bool DeleteProduct(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_Product", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productID", id);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        public List<Product> GetProductById(int productID) ///int formId
        {
            List<Product> ProductList = new List<Product>();

            Connection(); // Make sure this method opens the connection

            using (SqlCommand command = new SqlCommand("Sp_GetElementById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productID", productID);

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

        */

        [HttpPost]
        public bool UpdateProduct(Product product)
        {
            Connection();
            connection.Open();

            // Begin a transaction
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("UpdateProduct", connection, transaction)) // Pass the transaction here
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@productID", product.productID);
                        command.Parameters.AddWithValue("@productName", product.productName);
                        command.Parameters.AddWithValue("@productSize", product.productSize);
                        command.Parameters.AddWithValue("@description", product.description);
                        command.Parameters.AddWithValue("@price", product.Price); // Assuming product.Price is a decimal property
                        command.Parameters.AddWithValue("@categoryID", product.categoryID);
                        command.Parameters.AddWithValue("@brand", product.brand);
                        command.Parameters.AddWithValue("@stockQuantity", product.stockQuantity);
                        command.Parameters.AddWithValue("@productSource", product.productSource);
                        command.Parameters.AddWithValue("@sellerID", product.sellerID);
                        SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.VarBinary);
                        imageParameter.Value = product.image;
                        command.Parameters.Add(imageParameter);

                        int i = command.ExecuteNonQuery();

                        if (i > 0)
                        {
                            transaction.Commit(); // Commit the transaction if update is successful
                            return true;
                        }
                        else
                        {
                            transaction.Rollback(); // Rollback the transaction if update fails
                            return false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback the transaction on exception
                                            // Handle the exception as needed
                    throw;
                }
                finally
                {
                    connection.Close(); // Close the connection in the finally block
                }
            }
        }
    }
}


