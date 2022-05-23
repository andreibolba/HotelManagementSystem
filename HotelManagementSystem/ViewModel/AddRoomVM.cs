using HotelManagementSystem.Model.BusinessLogicLayer;
using HotelManagementSystem.Model.EntityLayer;
using HotelManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagementSystem.ViewModel
{
    class AddRoomVM:BaseVM
    {
        RoomBLL roomBLL = new RoomBLL();
        FeatureBLL featureBLL = new FeatureBLL();

        public static Users loggedUser;

        public int ID { get; set; }
        public int IDO { get; set; }

        private ICommand m_chooseFeatures;
        private ICommand m_deleteFeatures;
        private ICommand m_back;
        private ICommand m_add;

        public static Room editedRoom { get; set; }
        public static bool isEdited { get; set; }

        public ObservableCollection<Feature> features { get; set; }
        public ObservableCollection<Feature> selectedFeatures { get; set; }
        public ObservableCollection<string> featuresList { get; set; }
        public ObservableCollection<string> selectedFeaturesList { get; set; }
        public ObservableCollection<string> options { get; set; }
        public ComboBoxItem name { get; set; }
        public string number { get; set; }

        public string visibilityCombo { get; set; }
        public string visibilityLabel { get; set; }
        public string title { get; set; }
        public string btnTitle { get; set; }
        public string roomType { get; set; }
        public AddRoomVM()
        {
            selectedFeatures = new ObservableCollection<Feature>();
            features = new ObservableCollection<Feature>();
            selectedFeaturesList = new ObservableCollection<string>();
            featuresList = new ObservableCollection<string>();
            ID = -1;
            IDO = -1;
            features = featureBLL.getAllFeatures();
            if (isEdited == false)
            {
                visibilityCombo = "Visible";
                visibilityLabel = "Hidden";
                title = "Add room";
                btnTitle = "Add";
                featuresList = new ObservableCollection<string>();
                foreach (Feature feature in features)
                    featuresList.Add(feature.Name);
                return;
            }
            selectedFeatures = editedRoom.Features;
            foreach (Feature feature in selectedFeatures)
                selectedFeaturesList.Add(feature.Name);
            ObservableCollection<Feature> goodFeature = new ObservableCollection<Feature>();
            foreach (Feature feature in features)
            {
                bool ok = true;
                foreach(Feature selFeature in selectedFeatures)
                    if(feature.Id == selFeature.Id)
                    {
                        ok = false;
                        break;
                    }
                if(ok)
                    goodFeature.Add(feature);
            }
            features = goodFeature;
            foreach (Feature feature in features)
                featuresList.Add(feature.Name);
            visibilityLabel = "Visible";
            visibilityCombo = "Hidden";
            roomType = editedRoom.Name;
            number = editedRoom.Number.ToString();
            title = "Edit room";
            btnTitle = "Edit";
        }

        private void chooseFeature(object parameter)
        {
            int id = ID;
            selectedFeaturesList.Add(featuresList[ID]);
            selectedFeatures.Add(features[ID]);
            featuresList.RemoveAt(ID);
            features.RemoveAt(id);
            OnPropertyChanged("selectedFeaturesList");
            OnPropertyChanged("featuresList");
        }

        private void deleteFeature(object parameter)
        {
            int id = ID;
            featuresList.Add(selectedFeaturesList[ID]);
            features.Add(selectedFeatures[ID]);
            selectedFeaturesList.RemoveAt(ID);
            selectedFeatures.RemoveAt(id);
            OnPropertyChanged("selectedFeaturesList");
            OnPropertyChanged("featuresList");
        }

        private void back(object parameter)
        {
            AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
            adminMainPage.Show();
            Application.Current.Windows[0].Close();
        }
        private bool hasLetters(string text)
        {
            for (int i = 0; i < text.Length; i++)
                if (!(text[i] >= '0' && text[i] <= '9'))
                    return true;
            return false;
        }
        private void add(object parameter)
        {
            if (isEdited == false)
            {
                if (IDO == -1 && string.IsNullOrEmpty(number))
                {
                    MessageBox.Show("Fill al spaces");
                    return;
                }
                if (hasLetters(number) == false)
                {
                    Model.EntityLayer.Room room = new Model.EntityLayer.Room();
                    room.Name = name.Content.ToString();
                    room.Features = selectedFeatures;
                    room.Number = int.Parse(number);
                    roomBLL.addRoom(room);
                    MessageBox.Show("Room added succesfully!");
                    AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
                    adminMainPage.Show();
                    Application.Current.Windows[0].Close();
                    return;
                }
                MessageBox.Show("Number has letters");
                return;
            }
            if (hasLetters(number) == false)
            {
                Model.EntityLayer.Room room = new Model.EntityLayer.Room();
                room.Features = selectedFeatures;
                room.Number = int.Parse(number);
                room.Id = editedRoom.Id;
                roomBLL.editRoom(room);
                MessageBox.Show("Room updated succesfully!");
                AdminMainPage adminMainPage = new AdminMainPage(loggedUser);
                adminMainPage.Show();
                Application.Current.Windows[0].Close();
            }
        }

        public ICommand Choose
        {
            get
            {
                if(m_chooseFeatures==null)
                    m_chooseFeatures=new RelayCommand(chooseFeature);
                return m_chooseFeatures;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (m_deleteFeatures == null)
                    m_deleteFeatures = new RelayCommand(deleteFeature);
                return m_deleteFeatures;
            }
        }

        public ICommand Back
        {
            get
            {
                if (m_back == null)
                    m_back = new RelayCommand(back);
                return m_back;
            }
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
    }
}
