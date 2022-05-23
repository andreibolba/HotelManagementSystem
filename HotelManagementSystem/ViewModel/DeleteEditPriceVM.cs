using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelManagementSystem.ViewModel
{
    class DeleteEditPriceVM : BaseVM
    {
        PriceBLL priceBLL = new PriceBLL();
        public int ID { get; set; }
        public string roomType { get; set; }
        public string roomNumber { get; set; }
        public static Users loggedUser { get; set; }
        public static Room currentRoom { get; set; }
        public ObservableCollection<string> prices { get; set; }
        public ObservableCollection<Room> rooms { get; set; }

        public DeleteEditPriceVM()
        {
            roomType = "Name: " + currentRoom.Name;
            roomNumber = "Number: " + currentRoom.Number;
            prices= new ObservableCollection<string>();
            foreach (Price price in currentRoom.Prices)
                prices.Add(price.RoomPrice + " de la " + price.StartDate.ToString().Substring(0, 9) + " -> " + price.EndDate.ToString().Substring(0, 9));
        }

        private ICommand m_back;
        private ICommand m_delete;
        private ICommand m_edit;

        private void back(object parameter)
        {
            AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
            adminMainPage.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            AddRoomPrice addRoomPrice = new AddRoomPrice(loggedUser,currentRoom.Prices[ID]);
            addRoomPrice.Show();
            Application.Current.Windows[0].Close();
        }

        private void delete(object parameter)
        {
            priceBLL.deletePrice(currentRoom.Prices[ID]);
            MessageBox.Show("Price deleted succesfully");
            currentRoom.Prices.Remove(currentRoom.Prices[ID]);
            prices.RemoveAt(ID);
            OnPropertyChanged("prices");
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
