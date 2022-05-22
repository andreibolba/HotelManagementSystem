using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageOfferVM:BaseVM
    {
        OffersBLL offersBLL = new OffersBLL();
        public ObservableCollection<string> offers { get; set; }
        public int ID { get; set; }
        private ObservableCollection<Offers> offersList { get; set; }
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageOfferVM()
        {
            offersList = offersBLL.getOffers();
            offers = new ObservableCollection<string>();
            foreach (Offers offer in offersList)
                offers.Add(offer.Name+"-"+offer.Period+"zile("+offer.Price.ToString()+" Lei) perioada"+offer.StartDate+" - "+offer.EndDate);
        }

        private void add(object parameter)
        {
            AddServices add = new AddServices(loggedUser, "Add service");
            add.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            /*try
            {
                AddServices edit = new AddServices(loggedUser, "Edit services", servicesList[ID].Id,servicesList[ID]);
                edit.Show();
                Application.Current.Windows[0].Close();
            }catch (Exception ex)
            {
                MessageBox.Show("No element to edit!");
            }*/
        }

        private void delete(object parameter)
        {
            /*offersBLL.deleteService(servicesList[ID]);
            MessageBox.Show("User deleted succesfully!");
            servicesList.Remove(servicesList[ID]);
            services.Remove(services[ID]);*/
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
