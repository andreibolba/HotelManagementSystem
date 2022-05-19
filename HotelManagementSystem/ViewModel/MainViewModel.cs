using HotelManagementSystem.View;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public FeatureView featureView { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            FeatureViewModel viewModel = new FeatureViewModel();
            CurrentView = viewModel;
        }
    }
}
