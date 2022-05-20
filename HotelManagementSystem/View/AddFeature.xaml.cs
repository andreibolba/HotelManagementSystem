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
    /// Interaction logic for AddFeature.xaml
    /// </summary>
    public partial class AddFeature : Window
    {
        public AddFeature(Users loggedUser, string title)
        {
            AddFeatureVM.loggedUser = loggedUser;
            AddFeatureVM.title = title;
            InitializeComponent();
        }

        public AddFeature(Users loggedUser, string title,int id)
        {
            AddFeatureVM.loggedUser = loggedUser;
            AddFeatureVM.title = title;
            AddFeatureVM.id = id;
            InitializeComponent();
        }

    }
}
