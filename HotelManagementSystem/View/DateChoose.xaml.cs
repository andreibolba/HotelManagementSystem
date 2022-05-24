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
    /// Interaction logic for DateChoose.xaml
    /// </summary>
    public partial class DateChoose : Window
    {
        public DateChoose(UnLoggedUserVM user, int index)
        {
            ChooseDateVM.unLoggedUserVM = user;
            ChooseDateVM.index = index;
            InitializeComponent();
        }

        public DateChoose(ClientMainPageVM user, int index)
        {
            ChooseDateVM.clientMainPageVM = user;
            ChooseDateVM.index = index;
            InitializeComponent();
        }
    }
}
