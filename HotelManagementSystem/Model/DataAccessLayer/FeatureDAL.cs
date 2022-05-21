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
    public class FeatureDAL
    {
        public void AddFeature(Feature feature)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddFeature", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter name = new SqlParameter("@name", feature.Name);
                SqlParameter deleted = new SqlParameter("@deleted", feature.Deleted);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Feature> GetAllFeatures()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllFeatures", con);
                ObservableCollection<Feature> result = new ObservableCollection<Feature>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Feature feature = new Feature();
                    feature.Id = reader.GetInt32(0);
                    feature.Name = reader.GetString(1);
                    feature.Deleted = reader.GetString(2);
                    result.Add(feature);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void EditFeatures(Feature feature)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("FeatureUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@id", feature.Id);
                SqlParameter name = new SqlParameter("@name", feature.Name);
                SqlParameter deleted = new SqlParameter("@deleted", feature.Deleted);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFeature(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteFeature", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idFeature = new SqlParameter("@id", id);
                cmd.Parameters.Add(idFeature);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
