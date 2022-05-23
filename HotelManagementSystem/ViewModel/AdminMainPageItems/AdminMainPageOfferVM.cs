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
        private Offers currentOffer;
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageOfferVM()
        {
            ID = 0;
            offersList = offersBLL.getOffers();
            offers = new ObservableCollection<string>();
            foreach (Offers offer in offersList)
                offers.Add(offer.Name+"-"+offer.RoomName+"("+offer.Price.ToString()+" Lei) perioada "+offer.StartDate.ToString().Substring(0,9)+" -> "+offer.EndDate.ToString().Substring(0, 9));
        }

        private void add(object parameter)
        {
            
            View.AddOffer addOffer = new View.AddOffer(loggedUser);
            addOffer.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            try
            {
                View.AddOffer editOffer = new View.AddOffer(loggedUser, offersList[ID], true);
                editOffer.Show();
                Application.Current.Windows[0].Close();
            }catch (Exception ex)
            {
                MessageBox.Show("No element to edit!");
            }
        }

        private void delete(object parameter)
        {
            offersBLL.deleteOffer(offersList[ID]);
            MessageBox.Show("Offer deleted succesfully!");
            offersList.Remove(offersList[ID]);
            offers.Remove(offers[ID]);
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
