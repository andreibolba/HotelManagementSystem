using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel.UnloggedUserItems
{
    class UnloggedUserAvailableRoomsVM : BaseVM
    {
        private int id = 0;
        
        public static DateTime start { get; set; }
        public static DateTime end { get; set; }
        public string roomName { get; set; }
        public string roomNumber { get; set; }
        public string nextButton { get; set; }
        public string prevButton { get; set; }
        public ObservableCollection<string> features { get; set; }
        public string price { get; set; }
        public ObservableCollection<AvailableRooms> rooms { get; set; }

        private RoomBLL roomBLL = new RoomBLL();

        private ObservableCollection<AvailableRooms> getprices()
        {
            ObservableCollection<AvailableRooms> newRooms = new ObservableCollection<AvailableRooms>();

            for(int i = 0; i < rooms.Count; i++)
            {
                //Mai are bug-uri
                AvailableRooms newRoom=new AvailableRooms();
                newRoom=rooms[i];
                int a = i, b=i;
                for(int j=i+1;j<rooms.Count;j++)
                    if(rooms[j].Id != rooms[i].Id|| j==rooms.Count-1)
                    {
                        b = j-1;
                        break;
                    }
                if (a == b)
                    newRoom.Price = newRoom.Price * (end - start).Days;
                else{
                    int x = a, y = b;
                    newRoom.Price = newRoom.Price * (newRoom.EndDate - start).Days;
                    x++;
                    while (x < y)
                    {
                        newRoom.Price = newRoom.Price+ rooms[x].Price* (rooms[x].EndDate - rooms[x].StartDate).Days;
                        x++;
                    }
                    newRoom.Price = newRoom.Price + rooms[x].Price * (end - rooms[x].StartDate).Days;
                }
                i += b-a;
                newRooms.Add(newRoom);
            }

            return newRooms;
        }

        public UnloggedUserAvailableRoomsVM()
        {
            features = new ObservableCollection<string>();
            rooms = roomBLL.getAllAvailableRooms(start,end);
            rooms=getprices();
            if (rooms.Count != 0)
            {
                roomName = rooms[id].Name;
                roomNumber = rooms[id].Number.ToString();
                foreach (Feature feature in rooms[id].Features)
                    features.Add(feature.Name);
                price = "Price " + rooms[id].Price.ToString();
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
            if (id == rooms.Count - 1)
            {
                nextButton = "Hidden";
                OnPropertyChanged("nextButton");
            }
            features = new ObservableCollection<string>();
            roomName = rooms[id].Name;
            roomNumber = rooms[id].Number.ToString();
            foreach (Feature feature in rooms[id].Features)
                features.Add(feature.Name);
            price = "Price " + rooms[id].Price.ToString();
            OnPropertyChanged("roomName");
            OnPropertyChanged("roomNumber");
            OnPropertyChanged("features");
            OnPropertyChanged("price");
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
            price = "Price " + rooms[id].Price.ToString();
            OnPropertyChanged("roomName");
            OnPropertyChanged("roomNumber");
            OnPropertyChanged("features");
            OnPropertyChanged("price");
        }

        public ICommand Next
        {
            get
            {
                if (m_next == null)
                    m_next = new RelayCommand(next);
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
