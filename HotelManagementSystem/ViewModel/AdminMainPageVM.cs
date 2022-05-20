using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class AdminMainPageVM : BaseVM
    {
        public MainPageOptionVM mainPageOption{get; set;}

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }



        public static Users loggedUser;
        public string helloText { get; set; }


        public AdminMainPageVM()
        {
            helloText = "Hello, " + loggedUser.Username;
            OnPropertyChanged("helloText");
            mainPageOption = new MainPageOptionVM("rooms");
            CurrentView= mainPageOption;
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
    }
}
