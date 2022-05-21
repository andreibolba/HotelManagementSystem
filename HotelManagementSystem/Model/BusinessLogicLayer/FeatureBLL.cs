using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagementSystem.Model.BusinessLogicLayer
{
    public class FeatureBLL
    {
        FeatureDAL featureDAL=new FeatureDAL();

        public void addFeature(Feature feature)
        {
            featureDAL.AddFeature(feature);
        }

        public ObservableCollection<Feature> getAllFeatures()
        {
            return featureDAL.GetAllFeatures();
        }

        public void editFeature(Feature feature)
        {
            featureDAL.EditFeatures(feature);
        }

        public void deleteFeature(int id)
        {
            featureDAL.DeleteFeature(id);
        }
    }
}
