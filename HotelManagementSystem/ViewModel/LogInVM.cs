using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class LogInVM:BaseVM
    {

        Users loggedUser=new Users();
        UsersBLL userBLL = new UsersBLL();

        public string email { get; set; }
        public string password { get; set; }

        private ICommand m_signUp;
        private ICommand m_logIn;
        private ICommand m_back;

        public void signUp(object parameter)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Application.Current.Windows[0].Close();
        }

        public void back(object parameter)
        {
            UnLoggedUserServices unLoggedUser = new UnLoggedUserServices();
            unLoggedUser.Show();
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

        public ICommand Back
        {
            get
            {
                if (m_back == null)
                    m_back = new RelayCommand(back);
                return m_back;
            }
        }
    }
}
