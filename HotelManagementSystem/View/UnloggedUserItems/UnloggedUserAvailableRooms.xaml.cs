using HotelManagementSystem.ViewModel.UnloggedUserItems;
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

namespace HotelManagementSystem.View.UnloggedUserItems
{
    /// <summary>
    /// Interaction logic for UnloggedUserAvailableRooms.xaml
    /// </summary>
    public partial class UnloggedUserAvailableRooms : UserControl
    {
        public UnloggedUserAvailableRooms()
        {
            UnloggedUserAvailableRoomsVM.start = DateTime.Now;
            UnloggedUserAvailableRoomsVM.end = DateTime.Now;
            InitializeComponent();
        }
        public UnloggedUserAvailableRooms(DateTime start, DateTime end)
        {
            UnloggedUserAvailableRoomsVM.start = start;
            UnloggedUserAvailableRoomsVM.end = end;
            InitializeComponent();
        }
    }
}
