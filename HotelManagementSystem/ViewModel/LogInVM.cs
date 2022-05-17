using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class LogInVM:BaseVM
    {
        private ICommand m_signUp;
        private ICommand m_logIn;

        public void signUp(object parameter)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Application.Current.Windows[0].Close();
        }

        public void logIn(object parameter)
        {
            AdminMainPage adminMain = new AdminMainPage();
            adminMain.Show();
            Application.Current.Windows[0].Close();
        }
        public ICommand SignUp
        {
            get
            {
                if (m_signUp == null)
                    m_signUp = new RelayCommand(signUp);
                return m_signUp;
            }
        }

        public ICommand LogInButton
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
