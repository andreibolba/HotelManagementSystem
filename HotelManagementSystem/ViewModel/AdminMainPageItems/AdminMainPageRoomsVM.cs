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
        private ICommand m_delete;
        private ICommand m_edit;

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

        private void delete(object parameter)
        {
            roomBLL.deleteRoom(rooms[ID]);
            rooms.RemoveAt(ID);
            OnPropertyChanged("rooms");
            MessageBox.Show("Deleted succesfully");
        }
        private void edit(object parameter)
        {
            AddRoomVM.editedRoom = rooms[ID];
            AddRoom editRoom = new AddRoom(loggedUser,true);
            editRoom.Show();
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

        public ICommand Delete
        {
            get
            {
                if (m_delete == null)
                    m_delete = new RelayCommand(delete);
                return m_delete;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (m_edit == null)
                    m_edit = new RelayCommand(edit);
                return m_edit;
            }
        }
    }
}
