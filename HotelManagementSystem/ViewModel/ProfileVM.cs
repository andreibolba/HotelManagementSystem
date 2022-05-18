using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
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
    class ProfileVM :BaseVM
    {
        public static Users loggedUser;
        UsersBLL userBLL = new UsersBLL();

        public string fName { get; set; }
        public string lName { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string fullName { get; set; }
        public string visible { get; set; }

        public ProfileVM()
        {
            fName = loggedUser.FirstName;
            lName = loggedUser.SecondName;
            username = "@"+loggedUser.Username;
            email = loggedUser.Email;
            password = loggedUser.Password;
            phone = loggedUser.Phone;
            sex = loggedUser.Sex;
            birthday = loggedUser.Birthday.ToString().Substring(0,9);
            address=loggedUser.Address;
            fullName=fName+"\n"+lName;

            string role = loggedUser.Email.Substring(loggedUser.Email.IndexOf("@") + 1);
            switch (role)
            {
                case "admin.ro":
                    visible = "Hidden";
                    break;
                case "sundaystaff.ro":
                    visible = "Hidden";
                    break;
                default:
                    visible = "Visible";
                    break;
            }
        }

        private ICommand m_logOut; 
        private ICommand m_back;
        private ICommand m_edit;
        private ICommand m_delete;

        public void delete(object parameter)
        {
            userBLL.deleteUser(loggedUser);
            logOut(parameter);
        }

        public void edit(object parameter)
        {
            SignUp edit=new SignUp(loggedUser);
            edit.Show();
            Application.Current.Windows[0].Close();
        }

        public void back(object parameter)
        {
            string role = loggedUser.Email.Substring(loggedUser.Email.IndexOf("@") + 1);
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

        public ICommand Back
        {
            get
            {
                if(m_back==null)
                    m_back=new RelayCommand(back);
                return m_back;
            }
        }

        public ICommand Edit
        {
            get
            {
                if(m_edit==null)
                    m_edit=new RelayCommand(edit);
                return m_edit;
            }
        }

        public ICommand Delete
        {
            get
            {
                if(m_delete==null)
                    m_delete=new RelayCommand(delete);
                return m_delete;
            }
        }
    }
}
