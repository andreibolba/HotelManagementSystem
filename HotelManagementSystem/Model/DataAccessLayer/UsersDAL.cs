using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagementSystem.Model.DataAccessLayer
{
    public class UsersDAL
    {
        public ObservableCollection<Users> GetAllUsers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<Users> result = new ObservableCollection<Users>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users user = new Users();
                    user.IdUser = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.SecondName = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Password = reader.GetString(5);
                    user.Phone = reader.GetString(6);
                    user.Birthday = reader.GetDateTime(7);
                    user.Sex = reader.GetString(8);
                    user.Address = reader.GetString(9);
                    user.Picture = null;
                    user.Deleted = reader.GetString(11);
                    result.Add(user);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public Users logInUser(string email, string password)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                Users user = new Users();
                SqlCommand cmd = new SqlCommand("GetCurrentUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter userEmail = new SqlParameter("@email", email);
                SqlParameter userPassword = new SqlParameter("@pass", password);
                cmd.Parameters.Add(userEmail);
                cmd.Parameters.Add(userPassword);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.IdUser = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.SecondName = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Password = reader.GetString(5);
                    user.Phone = reader.GetString(6);
                    user.Birthday = reader.GetDateTime(7);
                    user.Sex = reader.GetString(8);
                    user.Address = reader.GetString(9);
                    user.Picture = null;
                    user.Deleted = reader.GetString(11);
                }
                reader.Close();
                return user;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
