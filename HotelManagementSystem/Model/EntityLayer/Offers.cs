using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    public class Offers:BasePropertyChanged
    {
        private int id;
        private string name;
        private string roomName;
        private DateTime startDate;
        private DateTime endDate;
        private int price;
        private int roomID;
        private string deleted;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
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

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        public int RoomId
        {
            get { return roomID; }
            set { roomID = value; }
        }
    }
}
