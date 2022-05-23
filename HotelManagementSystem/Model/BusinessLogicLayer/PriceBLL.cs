using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.BusinessLogicLayer
{
    class PriceBLL
    {
        PriceDAL priceDAL=new PriceDAL();

        public void addPrice(Price price)
        {
            priceDAL.AddPrice(price);
        }
    }
}
