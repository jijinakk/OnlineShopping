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
        

        ///<summary>
        ///signup form
        ///</summary>

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


        ///<summary>
        ///get the sign in details of customer
        ///</summary>
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
        /// 

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
        
        /// <summary>
        /// Add seller
        /// </summary>
        /// <param name="sellersignup"></param>
        /// <returns></returns>

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
            command.Parameters.AddWithValue("@password", sellersignup.password);

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
        /// <summary>
        /// Get the detyails of the seller
        /// </summary>
        /// <returns></returns>
        public List<SellerSignup> GetSellerDetails()
        {
            Connection();
            List<SellerSignup> SellerSignupList = new List<SellerSignup>();
            SqlCommand command = new SqlCommand("SPS_SellerSignup", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            data.Fill(dataTable);
            connection.Close();
            foreach (DataRow datarow in dataTable.Rows)
            {

                SellerSignupList.Add(
                    new SellerSignup
                    {
                        id = Convert.ToInt32(datarow["SellerId"]),
                        name = Convert.ToString(datarow["name"]),
                        gender = Convert.ToString(datarow["gender"])[0], // Take the first character
                        email = Convert.ToString(datarow["email"]),
                        phoneNumber = Convert.ToString(datarow["phoneNumber"]),
                        idNumber = Convert.ToString(datarow["idNumber"]),
                        city = Convert.ToString(datarow["city"]),
                        state = Convert.ToString(datarow["state"]),
                        country = Convert.ToString(datarow["country"]),
                        username = Convert.ToString(datarow["username"]),
                        password = Convert.ToString(datarow["password"])


                    });
            }
            return SellerSignupList;
        }

        
        public bool Contactus(Contactus contactus)
        {
            Connection();
            SqlCommand command = new SqlCommand("SP_Contactus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", contactus.name);
            command.Parameters.AddWithValue("@email", contactus.email);
            command.Parameters.AddWithValue("@subject", contactus.subject);
            command.Parameters.AddWithValue("@message", contactus.message);
           
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