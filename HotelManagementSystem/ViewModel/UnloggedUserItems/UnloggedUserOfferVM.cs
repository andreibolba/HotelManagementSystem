using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.UnloggedUserItems
{
    class UnloggedUserOfferVM:BaseVM
    {
        OffersBLL offersBLL = new OffersBLL();
        public ObservableCollection<string> offers { get; set; }
        private ObservableCollection<Offers> offersList { get; set; }

        public UnloggedUserOfferVM()
        {
            offersList = offersBLL.getOffers();
            offers = new ObservableCollection<string>();
            foreach (Offers offer in offersList)
                offers.Add(offer.Name + "-" + offer.RoomName + "(" + offer.Price.ToString() + " Lei in perioada:" + offer.StartDate + " - " + offer.EndDate+")");
        }
    }
}
