using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using HotelManagementSystem.Model.BusinessLogicLayer;

namespace HotelManagementSystem.ViewModel.AdminMainPageItems
{
    class AdminMainPageFeatureVM : BaseVM
    {
        FeatureBLL featureBLL = new FeatureBLL();
        public ObservableCollection<string> features { get; set; }
        public int ID { get; set; }
        private ObservableCollection<Feature> featuresList { get; set; }
        public static Users loggedUser { get; set; }
        private ICommand m_add;
        private ICommand m_edit;
        private ICommand m_delete;

        public AdminMainPageFeatureVM()
        {
            featuresList = featureBLL.getAllFeatures();
            features = new ObservableCollection<string>();
            foreach (Feature feature in featuresList)
                features.Add(feature.Name);
        }

        private void add(object parameter)
        {
            AddFeature add = new AddFeature(loggedUser, "Add feature");
            add.Show();
            Application.Current.Windows[0].Close();
        }

        private void edit(object parameter)
        {
            AddFeature edit = new AddFeature(loggedUser, "Edit feature", featuresList[ID].Id);
            edit.Show();
            Application.Current.Windows[0].Close();
        }

        private void delete(object parameter)
        {
            featureBLL.deleteFeature(featuresList[ID].Id);
            MessageBox.Show("User deleted succesfully!");
            featuresList.Remove(featuresList[ID]);
            features.Remove(features[ID]);
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
                if (m_delete == null)
                    m_delete = new RelayCommand(delete);
                return m_delete;
            }
        }
    }
}
