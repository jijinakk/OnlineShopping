using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using OnlineShopping.Models;
using System.Web.Mvc;

namespace OnlineShopping.Respository
{
    public class SigninRespository
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
       


        public string GetUserRole(string username, string password)
        {
            Connection();
            SqlCommand command = new SqlCommand("SP_GetValidatedUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            //   string hashedPassword = HashPassword(password);
            command.Parameters.AddWithValue("@password", password);

            connection.Open();
            var role = command.ExecuteScalar() as string;
            connection.Close();

            return role;
        }
    }
}