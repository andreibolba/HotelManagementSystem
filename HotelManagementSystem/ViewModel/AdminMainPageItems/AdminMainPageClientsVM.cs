using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageClientsVM:BaseVM
    {
        UsersBLL usersBLL = new UsersBLL();
        public int ID { get; set; }
        public ObservableCollection<Users> usersList { get; set; }
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageClientsVM()
        {
            usersList = usersBLL.GetAllClients();
        }

        private void add(object parameter)
        {
            //AddServices add = new AddServices(loggedUser, "Add service");
            //add.Show();
            //Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            //try
            //{
            //    AddServices edit = new AddServices(loggedUser, "Edit services", servicesList[ID].Id, servicesList[ID]);
            //    edit.Show();
            //    Application.Current.Windows[0].Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("No element to edit!");
            //}
        }

        private void delete(object parameter)
        {
            //servicesBLL.deleteService(servicesList[ID]);
            //MessageBox.Show("User deleted succesfully!");
            //servicesList.Remove(servicesList[ID]);
            //services.Remove(services[ID]);
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
