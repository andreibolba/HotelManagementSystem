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
    class AddOfferVM : BaseVM
    {
        OffersBLL offersBLL = new OffersBLL();
        RoomBLL roomBLL = new RoomBLL();

        public static Users loggedUser { get; set; }
        public static Offers offer { get; set; }
        public static bool isEdited { get; set; }

        public string name { get; set; }
        public int ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int price { get; set; }

        public string title { get; set; }
        public string btnTitle { get; set; }

        private ObservableCollection<Room> rooms;
        public ObservableCollection<string> roomsList { get; set; }

        private ICommand m_back;
        private ICommand m_add;

        public AddOfferVM()
        {
            rooms = roomBLL.getAllRooms();
            roomsList = new ObservableCollection<string>();
            foreach (Room room in rooms)
                roomsList.Add(room.Name);
            if (isEdited == false)
            {
                ID = 0;
                startDate = DateTime.Now;
                endDate = DateTime.Now;
                title = "Add offer";
                btnTitle = "Add";
                return;
            }
            title = "Edit offer";
            btnTitle = "Edit";
            name = offer.Name;
            startDate = offer.StartDate;
            endDate = offer.EndDate;
            for (int i = 0; i < rooms.Count; i++)
                if (rooms[i].Id == offer.RoomId)
                    ID = i;
            price = offer.Price;
        }

        private void back(object parameter)
        {
            AdminMainPage adminMain = new AdminMainPage(loggedUser);
            adminMain.Show();
            Application.Current.Windows[0].Close();
        }

        private void add(object paramter)
        {
            Offers newOffer = new Offers();
            if (isEdited == false)
            {
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("No name for offers");
                    return;
                }

                newOffer.Name = name;
                newOffer.Price = price;
                newOffer.StartDate = startDate;
                newOffer.EndDate = endDate;
                newOffer.RoomId = rooms[ID].Id;
                offersBLL.addOffer(newOffer);
                MessageBox.Show("Offer added succesfully");
                return;
            }
            newOffer.Id=offer.Id;
            newOffer.Name = name;
            newOffer.Price = price;
            newOffer.StartDate = startDate;
            newOffer.EndDate = endDate;
            newOffer.RoomId = rooms[ID].Id;
            offersBLL.editOffer(newOffer);
            MessageBox.Show("Offer updated succesfully");
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
                if (m_add == null)
                    m_add = new RelayCommand(add);
                return m_add;
            }
        }
    }
}
