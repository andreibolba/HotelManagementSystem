using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class LogInVM:BaseVM
    {
        Users loggedUser=new Users();
        UsersBLL userBLL = new UsersBLL();
        /*public LogInVM()
        {
            UsersList = userBLL.GetAllPersons();
        }

        public ObservableCollection<Users> UsersList
        {
            get => userBLL.UsersList;
            set => userBLL.UsersList = value;
        }*/

        public string email { get; set; }
        public string password { get; set; }

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
            if(string.IsNullOrEmpty(email)||string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Empty fields");
                return;
            }
            loggedUser=userBLL.getLoggedUser(email, password);
            if(loggedUser.IdUser==-1)
            {
                MessageBox.Show("Account not found!");
                return ;
            }
            string role=loggedUser.Email.Substring(loggedUser.Email.IndexOf("@")+1);
            switch (role)
            {
                case "admin.ro":
                    AdminMainPage adminMain = new AdminMainPage(loggedUser);
                    adminMain.Show();
                    break;
                case "sundaystaff.ro":
                    StaffMainPage staffMain = new StaffMainPage(loggedUser);
                    staffMain.Show();
                    break;
                default:
                    ClientMainPage clientMain = new ClientMainPage(loggedUser);
                    clientMain.Show();
                    break;
            }
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
