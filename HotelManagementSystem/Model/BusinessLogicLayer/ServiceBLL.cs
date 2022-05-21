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
    public class ServiceBLL
    {
        ServiceDAL servicesDAL = new ServiceDAL();

        public ObservableCollection<Services> gettAllService()
        {
            return servicesDAL.GetAllServices();
        }

        public void addService(Services service)
        {
            servicesDAL.AddService(service);
        }

        public void editService(Services service)
        {
            servicesDAL.EditService(service);
        }

        public void deleteService(Services service)
        {
            servicesDAL.DeleteService(service);
        }
    }
}
