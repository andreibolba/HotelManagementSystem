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
    class SignUpVM : BaseVM
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

        public string mainTitle { get; set; }
        public string backButtonText { get; set; }
        public string signButtonText { get; set; }
        public static bool isEdited { get; set; } = false;
        public static bool isAdmin { get; set; } = false;

        public static Users loggedUser { get; set; }
        public static Users editedUser { get; set; }

        public SignUpVM()
        {
            if (isEdited == true)
            {
                mainTitle = "Edit account!";
                backButtonText = "Back";
                signButtonText = "Edit";
                birthday = DateTime.Now;
                return;
            }
            mainTitle = "Create an account!";
            backButtonText = "Back to log in";
            signButtonText = "Sign Up";
            birthday = DateTime.Now;
        }

        private bool isFilled()
        {
            if (string.IsNullOrEmpty(fName))
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
            if (birthday == null)
                return false;
            return true;
        }

        private bool isEditedFilled()
        {
            if (string.IsNullOrEmpty(fName) == false)
                return true;
            if (string.IsNullOrEmpty(lName) == false)
                return true;
            if (string.IsNullOrEmpty(username) == false)
                return true;
            if (string.IsNullOrEmpty(email) == false)
                return true;
            if (string.IsNullOrEmpty(pass) == false)
                return true;
            if (string.IsNullOrEmpty(phone) == false)
                return true;
            if (string.IsNullOrEmpty(sex) == false)
                return true;
            if (string.IsNullOrEmpty(address) == false)
                return true;
            if (birthday == null)
                return true;
            return false;
        }

        private ICommand m_backToLogIn;
        private ICommand m_signUp;
        public void logIn(object parameter)
        {
            if (isEdited == false&&isAdmin==false)
            {
                LogIn logIn = new LogIn();
                logIn.Show();
                Application.Current.Windows[0].Close();
                return;
            }
            if (isAdmin == false)
            {
                Profile profile = new Profile(loggedUser);
                profile.Show();
                Application.Current.Windows[0].Close();
                return;
            }
            AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
            adminMainPage.Show();
            Application.Current.Windows[0].Close();
        }

        public void signUp(object parameter)
        {
            if (isEdited == false)
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
                    newUser.Picture = Image.FromFile("J:\\FMI-AnII\\Semestrul_2\\MVP\\HotelManagementSystem\\HotelManagementSystem\\Resources\\basic.jpg");
                    userBLL.addUser(newUser);
                    MessageBox.Show("Your account has been added!");
                    if (isAdmin == false)
                    {
                        LogIn logIn = new LogIn();
                        logIn.Show();
                        Application.Current.Windows[0].Close();
                        return;
                    }
                    AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
                    adminMainPage.Show();
                    Application.Current.Windows[0].Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return;
            }
            if (isAdmin == false)
            {
                if (isEditedFilled() == false)
                {
                    MessageBox.Show("Fill at least one!");
                    return;
                }
                if (string.IsNullOrEmpty(email) == false)
                {
                    Regex regexE = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match matchE = regexE.Match(email);
                    if (matchE.Success == false)
                    {
                        MessageBox.Show("Incorect email format!");
                        return;
                    }
                }

                try
                {
                    if (string.IsNullOrEmpty(fName) == false)
                        loggedUser.FirstName = fName;
                    if (string.IsNullOrEmpty(lName) == false)
                        loggedUser.SecondName = lName;
                    if (string.IsNullOrEmpty(username) == false)
                        loggedUser.Username = username;
                    if (string.IsNullOrEmpty(email) == false)
                        loggedUser.Email = email;
                    if (string.IsNullOrEmpty(pass) == false)
                        loggedUser.Password = pass;
                    if (string.IsNullOrEmpty(phone) == false)
                        loggedUser.Phone = phone;
                    if (string.IsNullOrEmpty(sex) == false)
                        loggedUser.Sex = sex;
                    if (string.IsNullOrEmpty(address) == false)
                        loggedUser.Address = address;
                    if (birthday != null)
                        loggedUser.Birthday = birthday;
                    userBLL.editUser(loggedUser);
                    MessageBox.Show("Your account has been edited!");
                    Profile profile = new Profile(loggedUser);
                    profile.Show();
                    Application.Current.Windows[0].Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return;
            }

            if (isEditedFilled() == false)
            {
                MessageBox.Show("Fill at least one!");
                return;
            }
            if (string.IsNullOrEmpty(email) == false)
            {
                Regex regexE = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchE = regexE.Match(email);
                if (matchE.Success == false)
                {
                    MessageBox.Show("Incorect email format!");
                    return;
                }
            }

            try
            {
                if (string.IsNullOrEmpty(fName) == false)
                    editedUser.FirstName = fName;
                if (string.IsNullOrEmpty(lName) == false)
                    editedUser.SecondName = lName;
                if (string.IsNullOrEmpty(username) == false)
                    editedUser.Username = username;
                if (string.IsNullOrEmpty(email) == false)
                    editedUser.Email = email;
                if (string.IsNullOrEmpty(pass) == false)
                    editedUser.Password = pass;
                if (string.IsNullOrEmpty(phone) == false)
                    editedUser.Phone = phone;
                if (string.IsNullOrEmpty(sex) == false)
                    editedUser.Sex = sex;
                if (string.IsNullOrEmpty(address) == false)
                    editedUser.Address = address;
                if (birthday != null)
                    editedUser.Birthday = birthday;
                userBLL.editUser(editedUser);
                MessageBox.Show("Your account has been edited!");
                AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
                adminMainPage.Show();
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
                if (m_signUp == null)
                    m_signUp = new RelayCommand(signUp);
                return m_signUp;
            }
        }
    }
}
