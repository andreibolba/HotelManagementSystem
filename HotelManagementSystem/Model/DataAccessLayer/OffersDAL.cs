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
    public class OffersDAL
    {
        public ObservableCollection<Offers> GetAllOffers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllOffer", con);
                ObservableCollection<Offers> result = new ObservableCollection<Offers>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Offers offer = new Offers();
                    offer.Id = reader.GetInt32(0);
                    offer.Name = reader.GetString(1);
                    offer.RoomName = reader.GetString(2);
                    offer.StartDate= reader.GetDateTime(3);
                    offer.EndDate= reader.GetDateTime(4);
                    offer.Price=reader.GetInt32(5);
                    result.Add(offer);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddOffer(Offers offers)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddOffer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter name = new SqlParameter("@name", offers.Name);
                SqlParameter roomId = new SqlParameter("@roomID", offers.RoomId);
                SqlParameter startDate = new SqlParameter("@startDate", offers.StartDate);
                SqlParameter endDate = new SqlParameter("@endDate", offers.EndDate);
                SqlParameter price = new SqlParameter("@price", offers.Price);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(roomId);
                cmd.Parameters.Add(startDate);
                cmd.Parameters.Add(endDate);
                cmd.Parameters.Add(price);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
