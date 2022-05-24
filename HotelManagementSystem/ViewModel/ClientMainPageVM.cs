using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using HotelManagementSystem.View.UnloggedUserItems;
using System;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    public class ClientMainPageVM:BaseVM
    {
        public static Users loggedUser;
        public string helloText { get; set; }

        public object CurrentView { get; set; }

        UnloggedUserServices unLoggedUserServices { get; set; }
        UnloggedUserOffers unloggedUserOffers { get; set; }
        UnloggedUserRooms unloggedUserRooms { get; set; }
        UnloggedUserAvailableRooms unloggedUserAvailableRooms { get; set; }


        public ClientMainPageVM()
        {
            helloText = "Hello, " + loggedUser.Username;
            OnPropertyChanged("helloText");
            unloggedUserRooms = new UnloggedUserRooms();
            CurrentView = unloggedUserRooms;
            unloggedUserOffers = new UnloggedUserOffers();
            unLoggedUserServices = new UnloggedUserServices();
            unloggedUserAvailableRooms = new UnloggedUserAvailableRooms();
        }

        private ICommand m_logOut;
        private ICommand m_profile;
        private ICommand m_rooms;
        private ICommand m_offers;
        private ICommand m_services;
        private ICommand m_available;

        private void rooms(object parameter)
        {
            CurrentView = unloggedUserRooms;
            OnPropertyChanged("CurrentView");
        }

        private void offers(object parameter)
        {
            CurrentView = unloggedUserOffers;
            OnPropertyChanged("CurrentView");
        }

        private void services(object parameter)
        {
            CurrentView = unLoggedUserServices;
            OnPropertyChanged("CurrentView");
        }

        private void available(object parameter)
        {
            DateChoose dateChoose = new DateChoose(this, 2);
            dateChoose.Show();
        }

        public void seeRooms(DateTime start, DateTime end)
        {
            unloggedUserAvailableRooms = new UnloggedUserAvailableRooms(start, end);
            CurrentView = unloggedUserAvailableRooms;
            OnPropertyChanged("CurrentView");
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

        public ICommand Service
        {
            get
            {
                if (m_services == null)
                    m_services = new RelayCommand(services);
                return m_services;
            }
        }

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
                if (m_profile == null)
                    m_profile = new RelayCommand(profile);
                return m_profile;
            }
        }

        public ICommand AvailableRooms
        {
            get
            {
                if (m_available == null)
                    m_available = new RelayCommand(available);
                return m_available;
            }
        }
    }
}
