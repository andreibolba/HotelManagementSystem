using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagementSystem.Model.DataAccessLayer
{
     class PriceDAL
    {
        public void AddPrice(Price price)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter roomID = new SqlParameter("@roomID",price.RoomID);
                SqlParameter startdate = new SqlParameter("@startdate", price.StartDate);
                SqlParameter enddate = new SqlParameter("@finishdate", price.EndDate);
                SqlParameter priceRoom = new SqlParameter("@price", price.RoomPrice);
                cmd.Parameters.Add(roomID);
                cmd.Parameters.Add(startdate);
                cmd.Parameters.Add(enddate);
                cmd.Parameters.Add(priceRoom);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeletePrice(Price price)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter priceID = new SqlParameter("@priceID", price.Id);
                cmd.Parameters.Add(priceID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void EditPrice(Price price)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdatePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter priceID = new SqlParameter("@priceID", price.Id);
                SqlParameter start = new SqlParameter("@startDate", price.StartDate);
                SqlParameter end = new SqlParameter("@endDate", price.EndDate);
                SqlParameter priceRoom = new SqlParameter("@price", price.RoomPrice);
                cmd.Parameters.Add(priceID);
                cmd.Parameters.Add(start);
                cmd.Parameters.Add(end);
                cmd.Parameters.Add(priceRoom);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
