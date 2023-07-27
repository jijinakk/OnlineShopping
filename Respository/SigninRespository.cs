using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

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
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
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
    }
}