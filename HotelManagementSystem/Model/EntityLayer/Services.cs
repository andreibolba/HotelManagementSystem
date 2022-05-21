using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    public class Services: BasePropertyChanged
    {
        private int id;
        private string name;
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
