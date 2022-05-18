using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
     class SignUpVM:BaseVM
    {
        UsersBLL userBLL = new UsersBLL();
        public string fName { get; set; }
        public string lName { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public string sex { get; set; }
        public string address { get; set; }
        public Bitmap pic { get; set; }

        private bool isFilled()
        {
            if(string.IsNullOrEmpty(fName))
                return false;
            if (string.IsNullOrEmpty(lName))
                return false;
            if (string.IsNullOrEmpty(username))
                return false;
            if (string.IsNullOrEmpty(email))
                return false;
            if (string.IsNullOrEmpty(pass))
                return false;
            if (string.IsNullOrEmpty(phone))
                return false;
            if (string.IsNullOrEmpty(sex))
                return false;
            if (string.IsNullOrEmpty(address))
                return false;
            if (birthday==null)
                return false;
            return true;
        }

        private ICommand m_backToLogIn;
        private ICommand m_signUp;
        public void logIn(object parameter)
        {
            LogIn logIn=new LogIn();
            logIn.Show();
            Application.Current.Windows[0].Close();
        }

        public void signUp(object parameter)
        {
            if (isFilled() == false)
            {
                MessageBox.Show("There are some empty fileds!");
                return;
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success == false)
            {
                MessageBox.Show("Incorect email format!");
                return;
            }
            try
            {
                Users newUser = new Users();
                newUser.FirstName = fName;
                newUser.SecondName = lName;
                newUser.Email = email;
                newUser.Phone = phone;
                newUser.Username = username;
                newUser.Deleted = "false";
                newUser.Address = address;
                newUser.Birthday = birthday;
                newUser.Sex = sex;
                newUser.Password = pass;
                userBLL.addUser(newUser);
                MessageBox.Show("Your account has been added!");
                LogIn logIn = new LogIn();
                logIn.Show();
                Application.Current.Windows[0].Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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

        public ICommand SignUpButton
        {
            get
            {
                if(m_signUp == null)
                    m_signUp= new RelayCommand(signUp);
                return m_signUp;
            }
        }
    }
}
