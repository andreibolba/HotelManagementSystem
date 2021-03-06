using System.Windows;
using System.Windows.Input;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;

namespace HotelManagementSystem.ViewModel
{
    class StaffMainPageVM:BaseVM
    {
        public static Users loggedUser;
        public string helloText { get; set; }

        public StaffMainPageVM()
        {
            helloText = "Hello, " + loggedUser.Username;
            OnPropertyChanged("helloText");
        }
        
        private ICommand m_logOut;
        private ICommand m_profile;

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
                if(m_logOut == null)
                    m_logOut=new RelayCommand(logOut);
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
    }
}
