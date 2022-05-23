using HotelManagementSystem.ViewModel;
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

namespace HotelManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddRoomPrice.xaml
    /// </summary>
    public partial class AddRoomPrice : Window
    {
        public AddRoomPrice(Users loggedUser)
        {
            AddRoomPriceVM.loggedUser = loggedUser;
            InitializeComponent();
        }

        public AddRoomPrice(Users loggedUser,Price price)
        {
            AddRoomPriceVM.loggedUser = loggedUser;
            AddRoomPriceVM.editedPrice = price;
            AddRoomPriceVM.isEdited = true;
            InitializeComponent();
        }
    }
}
