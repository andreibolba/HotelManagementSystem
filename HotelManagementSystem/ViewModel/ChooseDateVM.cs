using HotelManagementSystem.View.UnloggedUserItems;
using HotelManagementSystem.ViewModel.UnloggedUserItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelManagementSystem.ViewModel
{
    class ChooseDateVM:BaseVM
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public static int index { get; set; }

        public static UnLoggedUserVM unLoggedUserVM { get; set; }
        public static ClientMainPageVM clientMainPageVM { get; set; }
        public ChooseDateVM()
        {
            start = DateTime.Now;
            end = DateTime.Now;
        }

        private ICommand m_choose;

        private void choose(object parameter)
        {
            Application.Current.Windows[2].Close();
            if (index == 1)
            {
                unLoggedUserVM.seeRooms(start, end);
                return;
            }
            clientMainPageVM.seeRooms(start, end);
        }

        public ICommand Choose
        {
            get
            {
                if (m_choose==null)
                    m_choose = new RelayCommand(choose);
                return m_choose;
            }
        }
    }
}
