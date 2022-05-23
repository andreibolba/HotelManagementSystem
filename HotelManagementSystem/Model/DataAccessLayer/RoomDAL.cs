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
                    room.Number=reader.GetInt32(2);
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
            return rooms;
        }
    }
}
