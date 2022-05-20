using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageFeatureVM : BaseVM
    {
        public static Users loggedUser { get; set; } 
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        private void add(object parameter)
        {
            AddFeature add = new AddFeature(loggedUser, "Add feature");
            add.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            int id = 0;//trebe facut:))
            AddFeature edit = new AddFeature(loggedUser, "Edit feature",id);
            edit.Show();
            Application.Current.Windows[0].Close();
        }

        private void delete(object parameter)
        {

        }

        public ICommand Add
        {
            get
            {
                if (m_add == null)
                    m_add = new RelayCommand(add);
                return m_add;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (m_edit == null)
                    m_edit = new RelayCommand(edit);
                return m_edit;
            }
        }

        public ICommand Delete
        {
            get
            {
                if(m_delete == null)
                    m_delete= new RelayCommand(delete);
                return m_delete;
            }
        }
    }
}
