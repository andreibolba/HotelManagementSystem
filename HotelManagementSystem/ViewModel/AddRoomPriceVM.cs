using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using HotelManagementSystem.View.AdminMainPageItems;
using HotelManagementSystem.ViewModel.AdminMainPageItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class AddRoomPriceVM
    {
        PriceBLL priceBLL = new PriceBLL();
        public static Room currentRoom;
        public static Users loggedUser;
        public static Price editedPrice;
        public static bool isEdited { get; set; } = false;

        public string price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public string title { get; set; }
        public string btnTitle { get; set; }

        public AddRoomPriceVM()
        {
            if (isEdited == false)
            {
                currentRoom = AdminMainPageRoomsVM.currentRoom;
                startDate = DateTime.Now;
                endDate = DateTime.Now;
                title = "Add price";
                btnTitle = "Add";
                return;
            }
            price = editedPrice.RoomPrice.ToString();
            startDate=editedPrice.StartDate;
            endDate=editedPrice.EndDate;
            title = "Edit price";
            btnTitle = "Edit";
        }

        private ICommand m_back;
        private ICommand m_add;

        private void back(object parameter)
        {
            AdminMainPage adminMainPage=new AdminMainPage(loggedUser);
            adminMainPage.Show();
            Application.Current.Windows[0].Close();
        }

        private void add(object parameter)
        {
            if (isEdited == false)
            {
                if (string.IsNullOrEmpty(price) == false)
                {
                    Price priceRoom = new Price();
                    priceRoom.StartDate = startDate;
                    priceRoom.EndDate = endDate;
                    priceRoom.RoomPrice = Int32.Parse(price);
                    priceRoom.RoomID = currentRoom.Id;
                    priceBLL.addPrice(priceRoom);
                    MessageBox.Show("Price added");
                    return;
                }
                MessageBox.Show("Enter a price");
                return;
            }
            if (string.IsNullOrEmpty(price) == false)
            {
                editedPrice.StartDate = startDate;
                editedPrice.EndDate = endDate;
                editedPrice.RoomPrice = Int32.Parse(price);
                priceBLL.editPrice(editedPrice);
                MessageBox.Show("Price updated");
                return;
            }
            MessageBox.Show("Enter a price");
        }

        public ICommand Back
        {
            get
            {
                if (m_back == null)
                    m_back = new RelayCommand(back);
                return m_back;
            }
        }

        public ICommand Add
        {
            get
            {
                if(m_add == null)
                    m_add = new RelayCommand(add);
                return m_add;
            }
        }
    }
}
