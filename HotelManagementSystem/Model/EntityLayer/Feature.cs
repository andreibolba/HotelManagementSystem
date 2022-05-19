using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    public class Feature:BasePropertyChanged
    {
        private int? id;
        private string name;
        private string description;

        public Feature()
        {
            id = -1;
            name= string.Empty;
            description= string.Empty;
        }

        public int? Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return description; }
            set { 
                description = value; 
                NotifyPropertyChanged("Description"); 
            }
        }
    }
}
