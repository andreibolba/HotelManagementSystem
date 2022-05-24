using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    class AvailableRooms:BasePropertyChanged
    {
        private int id;
        private string name;
        private int number;
        private DateTime startDate;
        private DateTime endDate;
        private int price;
        private ObservableCollection<Feature> features;

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

        public int Number
        {
            get { return number; }
            set { number = value; }
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

        public ObservableCollection<Feature> Features
        {
            get { return features; }
            set { features = value; }
        }
    }
}
