using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.BusinessLogicLayer
{
    public class OffersBLL
    {
        OffersDAL offersDAL = new OffersDAL();

        public ObservableCollection<Offers> getOffers()
        {
            return offersDAL.GetAllOffers();
        }
    }
}
