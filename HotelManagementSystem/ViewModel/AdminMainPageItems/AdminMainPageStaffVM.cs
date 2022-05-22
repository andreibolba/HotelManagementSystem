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

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageStaffVM:BaseVM
    {
        UsersBLL usersBLL = new UsersBLL();
        public int ID { get; set; }
        public ObservableCollection<Users> usersList { get; set; }
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageStaffVM()
        {
            ID = 1;
            usersList = usersBLL.GetAllStaff();
        }

        private void add(object parameter)
        {
            SignUp signUp = new SignUp(loggedUser,true,false);
            signUp.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            try
            {
                SignUp signUp = new SignUp(loggedUser, usersList[ID],true);
                signUp.Show();
                Application.Current.Windows[0].Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No user to edit!");
            }
        }

        private void delete(object parameter)
        {
            usersBLL.deleteUser(usersList[ID]);
            MessageBox.Show("User deleted succesfully!");
            usersList.Remove(usersList[ID]);
        }

        public ICommand Add
        {
            get
            {
                if (m_add == null)
                    m_add = new RelayCommand(add);
                return m_add;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (m_edit == null)
                    m_edit = new RelayCommand(edit);
                return m_edit;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (m_delete == null)
                    m_delete = new RelayCommand(delete);
                return m_delete;
            }
        }
    }
}
