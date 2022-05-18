using System.Windows;
using System.Windows.Input;
using HotelManagementSystem.View;

namespace HotelManagementSystem.ViewModel
{
    class StaffMainPageVM:BaseVM
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
                if(m_logOut == null)
                    m_logOut=new RelayCommand(logOut);
                return m_logOut; 
            }
        }
    }
}
