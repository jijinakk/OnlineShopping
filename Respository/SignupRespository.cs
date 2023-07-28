using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Drawing;
using System.Diagnostics;

namespace OnlineShopping.Respository
{
    public class SignupRespository
    {
        private SqlConnection connection;


        private void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["GetConnection"].ToString();
            connection = new SqlConnection(conString);
        }
        /// <summary>
        /// Password enctrypting for database
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }






        public bool AddDetails(Signup signup)
        {
            Connection();
            SqlCommand command = new SqlCommand("[dbo].[SPI_Signup]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstName", signup.firstName);
            command.Parameters.AddWithValue("@lastName", signup.lastName);
            command.Parameters.AddWithValue("@dateOfBirth", signup.dateOfBirth);
            command.Parameters.AddWithValue("@gender", signup.gender);
            command.Parameters.AddWithValue("@email", signup.email);
            command.Parameters.AddWithValue("@phoneNumber", signup.phoneNumber);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@city", signup.city);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
            string hashedPassword = HashPassword(signup.password);
            command.Parameters.AddWithValue("@password", hashedPassword);
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
        public List<Signup> GetDetails()
        {
            Connection();
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
                    new Signup
                    {
                        id = Convert.ToInt32(datarow["Id"]),
                        firstName = Convert.ToString(datarow["firstName"]),
                        lastName = Convert.ToString(datarow["lastName"]),
                        dateOfBirth = Convert.ToDateTime(datarow["dateOfBirth"]),
                        gender = Convert.ToString(datarow["gender"])[0], // Take the first character
                        email = Convert.ToString(datarow["email"]),
                        phoneNumber = Convert.ToString(datarow["phoneNumber"]),
                        address = Convert.ToString(datarow["address"]),
                        city = Convert.ToString(datarow["city"]),
                        state = Convert.ToString(datarow["state"]),
                        pincode = Convert.ToInt32(datarow["pincode"]),
                        country = Convert.ToString(datarow["country"]),
                        username = Convert.ToString(datarow["username"]),
                        password = Convert.ToString(datarow["password"])


                    });
            }
            return SignupList;
        }
        /// <summary>
        /// Updating the signup record
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        public bool Edit(Signup signup)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", signup.id);

            command.Parameters.AddWithValue("@firstName", signup.firstName);
            command.Parameters.AddWithValue("@lastName", signup.lastName);
            command.Parameters.AddWithValue("@dateOfBirth", signup.dateOfBirth);
            command.Parameters.AddWithValue("@gender", signup.gender);
            command.Parameters.AddWithValue("@email", signup.email);
            command.Parameters.AddWithValue("@phoneNumber", signup.phoneNumber);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@city", signup.city);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
            string hashedPassword = HashPassword(signup.password);

            command.Parameters.AddWithValue("@password", signup.password);

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
        /// <summary>
        /// Deleting the signup record of the memeber with specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        public bool AddSellerDetails(SellerSignup sellersignup)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_SellerSignup", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", sellersignup.name);
            command.Parameters.AddWithValue("@gender", sellersignup.gender);
            command.Parameters.AddWithValue("@email", sellersignup.email);
            command.Parameters.AddWithValue("@phoneNumber", sellersignup.phoneNumber);
            command.Parameters.AddWithValue("@idNumber", sellersignup.idNumber);
            command.Parameters.AddWithValue("@city", sellersignup.city);
            command.Parameters.AddWithValue("@state", sellersignup.state);
            command.Parameters.AddWithValue("@country", sellersignup.country);
            command.Parameters.AddWithValue("@username", sellersignup.username);
            string hashedPassword = HashPassword(sellersignup.password);
            command.Parameters.AddWithValue("@password", hashedPassword);

            command.Parameters.AddWithValue("@usertype", sellersignup.usertype);

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
        public bool ValidateUser(string username, string password)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPS_ValidateUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            string hashedPassword = HashPassword(password);
            command.Parameters.AddWithValue("@password", hashedPassword);

            connection.Open();
            int result = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return result > 0;
        }



        public string GetCustomer(Signin signin)
        {
            Connection();
            SqlCommand command = new SqlCommand("[dbo].[SP_CustomerUserType]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@usertype", "customer"); // Assuming the parameter is "customer" for customers

            connection.Open();
            string result = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return result;
        }
        public string GetSeller(Signin signin)
        {
            Connection();
            SqlCommand command = new SqlCommand("[dbo].[SP_SellerUserType]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@usertype", "seller"); // Assuming the parameter is "seller" for sellers

            connection.Open();
            string result = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return result;
        }

    }
}