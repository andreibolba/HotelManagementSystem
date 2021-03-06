using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
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
    class AdminMainPageServicesVM : BaseVM
    {
        ServiceBLL servicesBLL = new ServiceBLL();
        public ObservableCollection<string> services { get; set; }
        public int ID { get; set; }
        private ObservableCollection<Services> servicesList { get; set; }
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageServicesVM()
        {
            servicesList = servicesBLL.gettAllService();
            services = new ObservableCollection<string>();
            foreach (Services service in servicesList)
                services.Add(service.Name+"("+service.Price.ToString()+" Lei)");
        }

        private void add(object parameter)
        {
            AddServices add = new AddServices(loggedUser, "Add service");
            add.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            try
            {
                AddServices edit = new AddServices(loggedUser, "Edit services", servicesList[ID].Id,servicesList[ID]);
                edit.Show();
                Application.Current.Windows[0].Close();
            }catch (Exception ex)
            {
                MessageBox.Show("No element to edit!");
            }
        }

        private void delete(object parameter)
        {
            servicesBLL.deleteService(servicesList[ID]);
            MessageBox.Show("User deleted succesfully!");
            servicesList.Remove(servicesList[ID]);
            services.Remove(services[ID]);
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
