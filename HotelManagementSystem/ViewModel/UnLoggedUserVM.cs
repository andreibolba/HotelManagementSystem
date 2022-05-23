using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HotelManagementSystem.View.UnloggedUserItems;

namespace HotelManagementSystem.ViewModel
{
    class UnLoggedUserVM:BaseVM
    {
        public object CurrentView { get; set; }

        UnloggedUserServices unLoggedUserServices{get; set; }
        UnloggedUserOffers unloggedUserOffers{get; set; }
        UnloggedUserRooms unloggedUserRooms{get; set; }

        public UnLoggedUserVM()
        {
            unloggedUserRooms = new UnloggedUserRooms();
            CurrentView = unloggedUserRooms;
            unloggedUserOffers = new UnloggedUserOffers();
            unLoggedUserServices= new UnloggedUserServices();
        }



        private ICommand m_logIn;
        private ICommand m_rooms;
        private ICommand m_offers;
        private ICommand m_services;

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

        private void logIn(object parameter)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Application.Current.Windows[0].Close();
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

        public ICommand LogIn
        {
            get
            {
                if (m_logIn == null)
                    m_logIn = new RelayCommand(logIn);
                return m_logIn;
            }
        }
    }
}
