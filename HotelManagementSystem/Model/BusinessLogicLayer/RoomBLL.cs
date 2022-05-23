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
        RoomDAL roomDal = new RoomDAL();

        public void addRoom(Room room)
        {
            roomDal.AddRoom(room);
        }

        public ObservableCollection<Room> getAllRooms()
        {
            return roomDal.getAllRooms();
        }
    }
}
