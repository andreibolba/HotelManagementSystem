using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.ViewModel.AdminMainPageItems;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagementSystem.View.AdminMainPageItems
{
    /// <summary>
    /// Interaction logic for AdminMainPageFeature.xaml
    /// </summary>
    public partial class AdminMainPageFeature : UserControl
    {
        public AdminMainPageFeature(Users loggedUser)
        {
            AdminMainPageFeatureVM.loggedUser = loggedUser;
            InitializeComponent();
        }
    }
}
