using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShopping.Respository
{
    public class AdminRespository
    {
        private SqlConnection connection;


        private void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            connection = new SqlConnection(conString);
        }
        public bool DeleteDetails(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("[dbo].[SPD_Signup]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
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
        public bool DeleteSellerDetails(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_SellerSignup", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
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
        public List<Contactus> FeedbackDetails()
        {
            Connection();
            List<Contactus> ContactusList = new List<Contactus>();
            SqlCommand command = new SqlCommand("SPS_FeedbackFromContactus", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            data.Fill(dataTable);
            connection.Close();
            foreach (DataRow datarow in dataTable.Rows)
            {

                ContactusList.Add(
                    new Contactus
                    {
                        name = Convert.ToString(datarow["name"]),
                        email = Convert.ToString(datarow["email"]),

                        subject = Convert.ToString(datarow["subject"]),
                        message = Convert.ToString(datarow["message"])


                    });
            }
            return ContactusList;


        }
        public bool AddProduct(Product product)
        {
            Connection();
            SqlCommand command = new SqlCommand("sp_InsertProduct", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@productName", product.productName);
            command.Parameters.AddWithValue("@productSize", product.productSize);

            command.Parameters.AddWithValue("@description", product.description);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@categoryID", product.categoryID);
            command.Parameters.AddWithValue("@brand", product.brand);
            command.Parameters.AddWithValue("@stockQuantity", product.stockQuantity);
            command.Parameters.AddWithValue("@imageURL", product.imageURL);
            command.Parameters.AddWithValue("@productSource", product.productSource);

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
    }
}