using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.DataAccessLayer
{
    public class ServiceDAL
    {
        public ObservableCollection<Services> GetAllServices()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllServices", con);
                ObservableCollection<Services> result = new ObservableCollection<Services>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Services services = new Services();
                    services.Id = reader.GetInt32(0);
                    services.Name = reader.GetString(1);
                    services.Price=reader.GetInt32(2);
                    services.Deleted = reader.GetString(3);
                    result.Add(services);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddService(Services service)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter name = new SqlParameter("@name", service.Name);
                SqlParameter price = new SqlParameter("@price", service.Price);
                SqlParameter deleted = new SqlParameter("@deleted", service.Deleted);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(price);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditService(Services services)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ServiceUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@id", services.Id);
                SqlParameter name = new SqlParameter("@name", services.Name);
                SqlParameter price = new SqlParameter("@price", services.Price);
                SqlParameter deleted = new SqlParameter("@deleted", services.Deleted);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(price);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteService(Services services)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@id", services.Id);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
