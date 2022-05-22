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
                SqlCommand cmd = new SqlCommand("GetAllOffers", con);
                ObservableCollection<Offers> result = new ObservableCollection<Offers>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Offers offer = new Offers();
                    offer.Id = reader.GetInt32(0);
                    offer.Name = reader.GetString(1);
                    offer.Room_Id = reader.GetInt32(2);
                    offer.Period= reader.GetInt32(3);
                    offer.StartDate= reader.GetDateTime(4);
                    offer.EndDate= reader.GetDateTime(5);
                    offer.Price=reader.GetInt32(6);
                    offer.Deleted=reader.GetString(7);
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
    }
}
