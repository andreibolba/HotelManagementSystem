using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    class Price : BasePropertyChanged
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private int roomPrice;
        private int roomId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int RoomPrice
        {
            get { return roomPrice; }
            set { roomPrice = value; }
        }

        public int RoomID
        {
            get { return roomId; }
            set { roomId = value; }
        }
    }
}
