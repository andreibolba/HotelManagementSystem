using HotelManagementSystem.View;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class AdminMainPageVM:BaseVM
    {
        private ICommand m_logOut;

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
    }
}
