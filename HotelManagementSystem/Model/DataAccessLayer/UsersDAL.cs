using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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

        public ObservableCollection<Users> GetAllStaff()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStaff", con);
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

        public ObservableCollection<Users> GetAllClients()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClients", con);
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

        private static readonly ImageConverter _imageConverter = new ImageConverter();
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
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
                    user.Deleted = reader.GetString(11);

                    int bufferSize = 32768;
                    byte[] outbyte = new byte[bufferSize];
                    long startIndex = 0;
                    int columnIndex = 10;
                    int bufferIndex = 0;
                    int bytesReceived = Convert.ToInt32(reader.GetBytes(columnIndex, startIndex, outbyte, bufferIndex, bufferSize));
                    //user.ProfilePic = GetImageFromByteArray(outbyte);
                }
                reader.Close();
                return user;
            }
            finally
            {
                con.Close();
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, format);
            return ms.ToArray();
        }

        public void AddPerson(Users user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                byte[] b = imageToByteArray(user.Picture, user.Picture.RawFormat);
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter fName = new SqlParameter("@fname", user.FirstName);
                SqlParameter lName = new SqlParameter("@lname", user.SecondName);
                SqlParameter username = new SqlParameter("@username", user.Username);
                SqlParameter email = new SqlParameter("@email", user.Email);
                SqlParameter pass = new SqlParameter("@pass", user.Password);
                SqlParameter phone = new SqlParameter("@phone", user.Phone);
                SqlParameter birthday = new SqlParameter("@birthday", user.Birthday);
                SqlParameter sex = new SqlParameter("@sex", user.Sex);
                SqlParameter address = new SqlParameter("@address", user.Address);
                SqlParameter param = cmd.Parameters.Add("@picture", SqlDbType.VarBinary);
                param.Value = b;
                SqlParameter deleted = new SqlParameter("@deleted", user.Deleted);
                cmd.Parameters.Add(fName);
                cmd.Parameters.Add(lName);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(pass);
                cmd.Parameters.Add(phone);
                cmd.Parameters.Add(birthday);
                cmd.Parameters.Add(sex);
                cmd.Parameters.Add(address);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void EditPic(Users user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                byte[] b = imageToByteArray(user.Picture, user.Picture.RawFormat);
                SqlCommand cmd = new SqlCommand("UserUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@userID", user.IdUser);
                cmd.Parameters.Add(id);
                SqlParameter param = cmd.Parameters.Add("@picture", SqlDbType.VarBinary);
                param.Value = b;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditPerson(Users user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UserUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@userID", user.IdUser);
                SqlParameter fName = new SqlParameter("@fname", user.FirstName);
                SqlParameter lName = new SqlParameter("@lname", user.SecondName);
                SqlParameter username = new SqlParameter("@username", user.Username);
                SqlParameter email = new SqlParameter("@email", user.Email);
                SqlParameter pass = new SqlParameter("@pass", user.Password);
                SqlParameter phone = new SqlParameter("@phone", user.Phone);
                SqlParameter birthday = new SqlParameter("@birthday", user.Birthday);
                SqlParameter sex = new SqlParameter("@sex", user.Sex);
                SqlParameter address = new SqlParameter("@address", user.Address);
                SqlParameter deleted = new SqlParameter("@deleted", user.Deleted);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(fName);
                cmd.Parameters.Add(lName);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(pass);
                cmd.Parameters.Add(phone);
                cmd.Parameters.Add(birthday);
                cmd.Parameters.Add(sex);
                cmd.Parameters.Add(address);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePerson(Users user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@userID", user.IdUser);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
