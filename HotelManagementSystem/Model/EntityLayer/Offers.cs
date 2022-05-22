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
        private int room_id;
        private int period;
        private DateTime startDate;
        private DateTime endDate;
        private int price;
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

        public int Room_Id
        {
            get { return room_id; }
            set { room_id = value; }
        }

        public int Period
        {
            get { return period; }
            set { period = value; }
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
    }
}
