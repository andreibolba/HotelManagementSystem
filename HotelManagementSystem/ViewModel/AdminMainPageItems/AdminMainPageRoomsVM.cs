using HotelManagementSystem.Model.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HotelManagementSystem.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageRoomsVM : BaseVM
    {
        RoomBLL roomBLL = new RoomBLL();
        public int ID { get; set; }
        public static Users loggedUser;
        public static Room currentRoom;
        public ObservableCollection<Room> rooms { get; set; }

        private ICommand m_add;
        private ICommand m_price;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageRoomsVM()
        {
            ID = 1;
            rooms = roomBLL.getAllRooms();
            OnPropertyChanged("rooms");
        }

        private void price(object parameter)
        {
            currentRoom = rooms[ID];
            View.AddRoomPrice a = new View.AddRoomPrice(loggedUser);
            a.Show();
            Application.Current.Windows[0].Close();
        }

        private void add(object parameter)
        {
            AddRoom addRoom = new AddRoom(loggedUser);
            addRoom.Show();
            Application.Current.Windows[0].Close();
        }

        public ICommand Add
        {
            get
            {
                if (m_add == null)
                    m_add=new RelayCommand(add);
                return m_add;
            }

        }

        public ICommand Price
        {
            get
            {
                if(m_price == null)
                    m_price=new RelayCommand(price);
                return m_price;
            }
        }
    }
}
