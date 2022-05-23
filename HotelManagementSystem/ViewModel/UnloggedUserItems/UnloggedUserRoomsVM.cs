using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel.UnloggedUserItems
{
    class UnloggedUserRoomsVM : BaseVM
    {
        private int id = 0;
        public string roomName { get; set; }
        public string roomNumber { get; set; }
        public string nextButton { get; set; }
        public string prevButton { get; set; }
        public ObservableCollection<string> features { get; set; }
        public ObservableCollection<string> price { get; set; }
        public ObservableCollection<Room> rooms { get; set; }

        private RoomBLL roomBLL = new RoomBLL();

        public UnloggedUserRoomsVM()
        {
            features = new ObservableCollection<string>();
            rooms = roomBLL.getAllRooms();
            if (rooms.Count != 0)
            {
                roomName = rooms[id].Name;
                roomNumber = rooms[id].Number.ToString();
                foreach (Feature feature in rooms[id].Features)
                    features.Add(feature.Name);
                if (id == 0)
                {
                    prevButton = "Hidden";
                    nextButton = "Visible";
                }
                if (id == rooms.Count - 1)
                {
                    nextButton = "Hidden";
                }
                return;
            }
            roomName = "no room";
            roomNumber = "-1";
            prevButton = "Hidden";
            nextButton = "Hidden";
        }

        private ICommand m_next;
        private ICommand m_prev;

        private void next(object parameter)
        {
            id++;
            if (id == 1)
            {
                prevButton = "Visible";
                OnPropertyChanged("prevButton");
            }
            if(id==rooms.Count - 1)
            {
                nextButton = "Hidden";
                OnPropertyChanged("nextButton");
            }
            features = new ObservableCollection<string>();
            roomName = rooms[id].Name;
            roomNumber = rooms[id].Number.ToString();
            foreach (Feature feature in rooms[id].Features)
                features.Add(feature.Name);
            OnPropertyChanged("roomName");
            OnPropertyChanged("roomNumber");
            OnPropertyChanged("features");
        }

        private void prev(object parameter)
        {
            id--;
            if (id == 0)
            {
                prevButton = "Hidden";
                OnPropertyChanged("prevButton");
            }
            if (id == rooms.Count - 2)
            {
                nextButton = "Visible";
                OnPropertyChanged("nextButton");
            }
            features = new ObservableCollection<string>();
            roomName = rooms[id].Name;
            roomNumber = rooms[id].Number.ToString();
            foreach (Feature feature in rooms[id].Features)
                features.Add(feature.Name);
            OnPropertyChanged("roomName");
            OnPropertyChanged("roomNumber");
            OnPropertyChanged("features");
        }

        public ICommand Next
        {
            get
            {
                if(m_next == null)
                    m_next=new RelayCommand(next);
                return m_next;
            }
        }

        public ICommand Prev
        {
            get
            {
                if (m_prev == null)
                    m_prev = new RelayCommand(prev);
                return m_prev;
            }
        }
    }
}
