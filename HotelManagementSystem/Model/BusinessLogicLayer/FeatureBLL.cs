using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
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
    }
}
