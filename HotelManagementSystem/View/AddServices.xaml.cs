using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagementSystem.ViewModel
{
    /// <summary>
    /// Interaction logic for AddServices.xaml
    /// </summary>
    public partial class AddServices : Window
    {
        public AddServices(Users loggedUser, string title)
        {
            AddServicesVM.loggedUser = loggedUser;
            AddServicesVM.title = title;
            InitializeComponent();
        }

        public AddServices(Users loggedUser, string title,int id)
        {
            AddServicesVM.loggedUser = loggedUser;
            AddServicesVM.title = title;
            AddServicesVM.id = id;
            InitializeComponent();
        }

        public AddServices(Users loggedUser, string title, int id,Services services)
        {
            AddServicesVM.loggedUser = loggedUser;
            AddServicesVM.title = title;
            AddServicesVM.id = id;
            AddServicesVM.editService=services;
            InitializeComponent();
        }
        }
    }
