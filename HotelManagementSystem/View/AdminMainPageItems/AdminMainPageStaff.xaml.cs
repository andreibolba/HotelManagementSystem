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
    /// Interaction logic for AdminMainPageStaff.xaml
    /// </summary>
    public partial class AdminMainPageStaff : UserControl
    {
        public AdminMainPageStaff(Users loggedUser)
        {
            AdminMainPageStaffVM.loggedUser = loggedUser;
            InitializeComponent();
        }
    }
}
