using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.ViewModel;
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

namespace HotelManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddOffer.xaml
    /// </summary>
    public partial class AddOffer : Window
    {
        public AddOffer(Users loggedUser)
        {
            AddOfferVM.loggedUser= loggedUser;
            InitializeComponent();
        }

        public AddOffer(Users loggedUser,Offers offers,bool isEdited)
        {
            AddOfferVM.loggedUser = loggedUser;
            AddOfferVM.offer= offers;
            AddOfferVM.isEdited= isEdited;
            InitializeComponent();
        }
    }
}
