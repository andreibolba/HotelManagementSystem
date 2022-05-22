using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
        public Image profileImageFromDB { get; set; }


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
            profileImageFromDB = loggedUser.Picture;


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
        private ICommand m_addPic;

        public void delete(object parameter)
        {
            userBLL.deleteUser(loggedUser);
            logOut(parameter);
        }

        public void edit(object parameter)
        {
            SignUp edit=new SignUp(loggedUser);
            edit.Show();
            System.Windows.Application.Current.Windows[0].Close();
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
            System.Windows.Application.Current.Windows[0].Close();
        }

        public void logOut(object parameter)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }

        public void addPic(object parameter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;

                Image image1 = Image.FromFile(selectedFileName);
                profileImageFromDB = image1;
                loggedUser.Picture = image1;
                userBLL.editPic(loggedUser);
                OnPropertyChanged("profileImage");
                OnPropertyChanged("profileImageVisibility");
                OnPropertyChanged("profileImageFromDBVisibility");
            }
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

        public ICommand AddPic
        {
            get
            {
                if (m_addPic == null)
                    m_addPic = new RelayCommand(addPic);
                return m_addPic;
            }
        }
    }
}
