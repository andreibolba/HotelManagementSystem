using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagementSystem.ViewModel
{
    class MainPageOptionVM:BaseVM
    {
        public string mainTitle { get; set; }
        public string addButton { get; set; }
        public string editButton { get; set; }
        public string deleteButton { get; set; }
        public string backButton { get; set; }

        public MainPageOptionVM(string title)
        {
            mainTitle = title;
            addButton = "Add " + title;
            editButton = "Edit " + title;
            deleteButton = "Delete " + title;
            backButton = "Back";
        }
    }
}
