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
     class SignUpVM:BaseVM
    {
        private ICommand m_backToLogIn;
        public void logIn(object parameter)
        {
            LogIn logIn=new LogIn();
            logIn.Show();
            Application.Current.Windows[0].Close();
        }
        public ICommand LogInButton
        {
            get
            {
                if (m_backToLogIn == null)
                    m_backToLogIn = new RelayCommand(logIn);
                return m_backToLogIn;
            }
        }
    }
}
