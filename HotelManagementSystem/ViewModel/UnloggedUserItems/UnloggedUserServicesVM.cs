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
    class UnloggedUserServicesVM:BaseVM
    {
        ServiceBLL servicesBLL = new ServiceBLL();
        public ObservableCollection<string> services { get; set; }
        private ObservableCollection<Services> servicesList { get; set; }

        public UnloggedUserServicesVM()
        {
            servicesList = servicesBLL.gettAllService();
            services = new ObservableCollection<string>();
            foreach (Services service in servicesList)
                services.Add(service.Name + "(" + service.Price.ToString() + " Lei)");
        }
    }
}
