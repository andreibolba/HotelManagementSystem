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
    class RoomDAL
    {
        public void AddRoom(Room room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter name = new SqlParameter("@name", room.Name);
                SqlParameter numbers = new SqlParameter("@number", room.Number);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(numbers);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            int id = -1;
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllRoomsID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    id = reader.GetInt32(0);
                reader.Close();
                con.Close();
            }


            using (SqlConnection con = DALHelper.Connection)
            {
                foreach (Feature feature in room.Features)
                {
                    SqlCommand cmd = new SqlCommand("AddRoomFeature", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter name = new SqlParameter("@id_feature", feature.Id);
                    SqlParameter numbers = new SqlParameter("@id_room", id);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(numbers);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public ObservableCollection<AvailableRooms> getAllAvailableRooms(DateTime start,DateTime finish)
        {
            ObservableCollection<AvailableRooms> rooms = new ObservableCollection<AvailableRooms>();
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GettRommsBetweenDates", con);
                SqlParameter startDate = new SqlParameter("@startDate", start);
                SqlParameter finishDate = new SqlParameter("@endDate", finish);
                cmd.Parameters.Add(startDate);
                cmd.Parameters.Add(finishDate);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AvailableRooms room = new AvailableRooms();
                    room.Id = reader.GetInt32(0);
                    room.Name = reader.GetString(1);
                    room.Number = reader.GetInt32(2);
                    room.StartDate=reader.GetDateTime(3);
                    room.EndDate=reader.GetDateTime(4);
                    room.Price = reader.GetInt32(5);
                    rooms.Add(room);
                }
                reader.Close();
                con.Close();
            }


            foreach (AvailableRooms room in rooms)
            {
                ObservableCollection<Feature> features = new ObservableCollection<Feature>();
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("GetAllRoomsFeature", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter userEmail = new SqlParameter("@id", room.Id);
                    cmd.Parameters.Add(userEmail);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Feature feature = new Feature();
                        feature.Id = reader.GetInt32(0);
                        feature.Name = reader.GetString(1);
                        feature.Deleted = reader.GetString(2);
                        features.Add(feature);
                    }
                    reader.Close();
                    con.Close();
                }
                room.Features = features;
            }
            return rooms;
        }

        public ObservableCollection<Room> getAllRooms()
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllRooms", con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Room room = new Room();
                    room.Id = reader.GetInt32(0);
                    room.Name = reader.GetString(1);
                    room.Number = reader.GetInt32(2);
                    rooms.Add(room);
                }
                reader.Close();
                con.Close();
            }

            foreach (Room room in rooms)
            {
                ObservableCollection<Feature> features = new ObservableCollection<Feature>();
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("GetAllRoomsFeature", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter userEmail = new SqlParameter("@id", room.Id);
                    cmd.Parameters.Add(userEmail);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Feature feature = new Feature();
                        feature.Id = reader.GetInt32(0);
                        feature.Name = reader.GetString(1);
                        feature.Deleted = reader.GetString(2);
                        features.Add(feature);
                    }
                    reader.Close();
                    con.Close();
                }
                room.Features = features;
            }

            foreach (Room room in rooms)
            {
                ObservableCollection<Price> prices = new ObservableCollection<Price>();
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("GetPrices", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter userEmail = new SqlParameter("@roomID", room.Id);
                    cmd.Parameters.Add(userEmail);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Price price = new Price();
                        price.Id = reader.GetInt32(0);
                        price.StartDate = reader.GetDateTime(1);
                        price.EndDate = reader.GetDateTime(2);
                        price.RoomPrice = reader.GetInt32(3);
                        prices.Add(price);
                    }
                    reader.Close();
                    con.Close();
                }
                room.Prices = prices;
            }
            return rooms;
        }

        public void DeletRoom(Room room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@roomID", room.Id);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }

        public void EditRoom(Room room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@roomID", room.Id);
                SqlParameter number = new SqlParameter("@number", room.Number);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(number);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            using (SqlConnection con = DALHelper.Connection)
            {
                foreach (Feature feature in room.Features)
                {
                    SqlCommand cmd = new SqlCommand("AddRoomFeature", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter name = new SqlParameter("@id_feature", feature.Id);
                    SqlParameter numbers = new SqlParameter("@id_room", room.Id);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(numbers);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
