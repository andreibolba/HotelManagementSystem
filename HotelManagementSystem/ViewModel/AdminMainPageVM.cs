using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using HotelManagementSystem.View.AdminMainPageItems;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class AdminMainPageVM : BaseVM
    {
        public AdminMainPageRooms adminMainPageRooms { get; set; }
        public AdminMainPageServices adminMainPageServices { get; set; }
        public AdminMainPageStaff adminMainPageStaff { get; set; }
        public AdminMainPageClients adminMainPageClients { get; set; }
        public AdminMainPageFeature adminMainPageFeature { get; set; }
        public AdminMainPageOffers adminMainPageOffers { get; set; }


        public object CurrentView { get; set; }



        public static Users loggedUser;
        public string helloText { get; set; }


        public AdminMainPageVM()
        {
            helloText = "Hello, " + loggedUser.Username;
            OnPropertyChanged("helloText");
            adminMainPageRooms=new AdminMainPageRooms();
            CurrentView = adminMainPageRooms;
            adminMainPageClients=new AdminMainPageClients();
            adminMainPageFeature=new AdminMainPageFeature(loggedUser);
            adminMainPageServices=new AdminMainPageServices(loggedUser);
            adminMainPageStaff = new AdminMainPageStaff(loggedUser);
            adminMainPageOffers=new AdminMainPageOffers();
        }



        private ICommand m_logOut;
        private ICommand m_profile;
        private ICommand m_rooms;
        private ICommand m_features;
        private ICommand m_staff;
        private ICommand m_services;
        private ICommand m_client;
        private ICommand m_offers;

        public void profile(object parameter)
        {
            Profile profile = new Profile(loggedUser);
            profile.Show();
            Application.Current.Windows[0].Close();
        }

        public void logOut(object parameter)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Application.Current.Windows[0].Close();
        }

        public void rooms(object parameter)
        {
            CurrentView = adminMainPageRooms;
            OnPropertyChanged("CurrentView");
        }

        public void staff(object parameter)
        {
            CurrentView = adminMainPageStaff;
            OnPropertyChanged("CurrentView");
        }

        public void features(object parameter)
        {
            CurrentView = adminMainPageFeature;
            OnPropertyChanged("CurrentView");
        }

        public void clients(object parameter)
        {
            CurrentView = adminMainPageClients;
            OnPropertyChanged("CurrentView");
        }

        public void services(object parameter)
        {
            CurrentView = adminMainPageServices;
            OnPropertyChanged("CurrentView");
        }

        public void offers(object parameter)
        {
            CurrentView = adminMainPageOffers;
            OnPropertyChanged("CurrentView");
        }

        public ICommand LogOut
        {
            get
            {
                if (m_logOut == null)
                    m_logOut = new RelayCommand(logOut);
                return m_logOut;
            }
        }

        public ICommand Profile
        {
            get
            {
                if(m_profile == null)
                    m_profile=new RelayCommand(profile);
                return m_profile;
            }
        }

        public ICommand Staff
        {
            get
            {
                if (m_staff == null)
                    m_staff = new RelayCommand(staff);
                return m_staff; 
            }
        }

        public ICommand Clients
        {
            get
            {
                if (m_client == null)
                    m_client = new RelayCommand(clients);
                return m_client;
            }
        }

        public ICommand Features
        {
            get
            {
                if (m_features == null)
                    m_features = new RelayCommand(features);
                return m_features;
            }
        }

        public ICommand Services
        {
            get
            {
                if (m_services == null)
                    m_services = new RelayCommand(services);
                return m_services;
            }
        }

        public ICommand Rooms
        {
            get
            {
                if (m_rooms == null)
                    m_rooms = new RelayCommand(rooms);
                return m_rooms;
            }
        }

        public ICommand Offers
        {
            get
            {
                if (m_offers == null)
                    m_offers = new RelayCommand(offers);
                return m_offers;
            }
        }
    }
}
