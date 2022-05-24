using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.BusinessLogicLayer
{
     class RoomBLL
    {
        RoomDAL roomDAL = new RoomDAL();

        public void addRoom(Room room)
        {
            roomDAL.AddRoom(room);
        }

        public ObservableCollection<Room> getAllRooms()
        {
            return roomDAL.getAllRooms();
        }

        public ObservableCollection<AvailableRooms> getAllAvailableRooms(DateTime start,DateTime finish)
        {
            return roomDAL.getAllAvailableRooms(start,finish);
        }

        public void deleteRoom(Room room)
        {
            roomDAL.DeletRoom(room);
        }

        public void editRoom(Room room)
        {
            roomDAL.EditRoom(room);
        }
    }
}
