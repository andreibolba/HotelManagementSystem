using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
