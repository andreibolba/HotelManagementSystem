using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModel
{
    class AddFeatureVM:BaseVM
    {
        public string featureName { get; set; }
        public string featureNameLabel { get; set; }
        public string titleBind { get; set; }
        public static string title { get; set; }
        public static int id { get; set; }
        public static Users loggedUser { get; set; }
        private FeatureBLL featureBLL = new FeatureBLL();

        public AddFeatureVM()
        {
            titleBind = title;
            if (title.ToString() == "Add feature")
            {
                featureNameLabel = "Feature name";
                return;
            }
            featureNameLabel = "Feature new name";
        }

        private ICommand m_addEdit;
        private ICommand m_back;

        public void addEdit(object parameter)
        {
            if(title=="Add feature")
            {
                if(string.IsNullOrEmpty(featureName))
                {
                    MessageBox.Show("Insert a name!");
                    return;
                }
                Feature newFeature=new Feature();
                newFeature.Name= featureName;
                newFeature.Deleted = "false";
                featureBLL.addFeature(newFeature);
                MessageBox.Show("New feature added succesfully!");
                return;
            }
            MessageBox.Show("Edit");
        }

        public void back(object parameter)
        {
            AdminMainPage adminMain = new AdminMainPage(loggedUser);
            adminMain.Show();
            Application.Current.Windows[0].Close();
        }

        public ICommand AddEdit
        {
            get { 
                if(m_addEdit == null)
                    m_addEdit = new RelayCommand(addEdit);
                return m_addEdit; 
            }
        }

        public ICommand Back
        {
            get { 
                if(m_back == null)
                    m_back=new RelayCommand(back);
                return m_back; 
            }
        }
    }
}
