using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelManagementSystem.ViewModel
{
    class AddServicesVM : BaseVM
    {
        public string serviceName { get; set; }
        public string serviceNameLabel { get; set; }
        public string servicePrice { get; set; }
        public string servicePriceLabel { get; set; }
        public string titleBind { get; set; }
        public static string title { get; set; }
        public static int id { get; set; }
        public static Users loggedUser { get; set; }
        private ServiceBLL servicesBLL = new ServiceBLL();
        public static Services editService { get; set; }

        public AddServicesVM()
        {
            titleBind = title;
            if (title.ToString() == "Add service")
            {
                serviceNameLabel = "Service name";
                servicePriceLabel = "Service price";
                return;
            }
            serviceNameLabel = "Service new name";
            servicePriceLabel = "Service new price";
        }

        private ICommand m_addEdit;
        private ICommand m_back;

        private bool hasLetters(string text)
        {
            for (int i = 0; i < text.Length; i++)
                if (!(text[i] >= '0' && text[i] <= '9'))
                    return true;
            return false;
        }

        public void addEdit(object parameter)
        {
            Services newService = new Services();
            if (title == "Add service")
            {
                if (string.IsNullOrEmpty(serviceName)||string.IsNullOrEmpty(servicePrice))
                {
                    MessageBox.Show("Insert all fields!");
                    return;
                }
                newService.Name = serviceName;
                if(hasLetters(servicePrice))
                {
                    MessageBox.Show("Price has letters!");
                    return;
                }
                newService.Price = int.Parse(servicePrice);
                newService.Deleted = "false";
                servicesBLL.addService(newService);
                MessageBox.Show("New service added succesfully!");
                return;
            }
            if (string.IsNullOrEmpty(serviceName)==false||string.IsNullOrEmpty(servicePrice)==false)
            {
                if(string.IsNullOrEmpty(serviceName)==false)
                    editService.Name= serviceName;
                if (string.IsNullOrEmpty(servicePrice) == false)
                {
                    if (hasLetters(servicePrice))
                    {
                        MessageBox.Show("Price has letters!");
                        return;
                    }
                    editService.Price= int.Parse(servicePrice);
                }
                servicesBLL.editService(editService);
                MessageBox.Show("Update service succesfully!");
                return;
            }
            MessageBox.Show("Insert at least one field!");
        }

        public void back(object parameter)
        {
            AdminMainPage adminMain = new AdminMainPage(loggedUser);
            adminMain.Show();
            Application.Current.Windows[0].Close();
        }

        public ICommand AddEdit
        {
            get
            {
                if (m_addEdit == null)
                    m_addEdit = new RelayCommand(addEdit);
                return m_addEdit;
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