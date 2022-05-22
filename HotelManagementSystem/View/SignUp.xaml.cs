using HotelManagementSystem.Model.EntityLayer;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            SignUpVM.isEdited = false;
            InitializeComponent();
        }

        public SignUp(Users loggedUser,bool isAdmin,bool isEdited)
        {
            SignUpVM.loggedUser = loggedUser;
            SignUpVM.isEdited = isEdited;
            SignUpVM.isAdmin = isAdmin;
            MessageBox.Show(isAdmin.ToString());
            InitializeComponent();
        }

        public SignUp(Users loggedUser)
        {
            SignUpVM.loggedUser = loggedUser;
            SignUpVM.isEdited = true;
            InitializeComponent();
        }
        public SignUp(Users loggedUser,bool isAdmin)
        {
            SignUpVM.loggedUser = loggedUser;
            SignUpVM.isEdited = true;
            SignUpVM.isAdmin = isAdmin;
            InitializeComponent();
        }

        public SignUp(Users loggedUser,Users editedUser, bool isAdmin)
        {
            SignUpVM.loggedUser = loggedUser;
            SignUpVM.editedUser=editedUser;
            SignUpVM.isEdited = true;
            SignUpVM.isAdmin = isAdmin;
            InitializeComponent();
        }
    }
}
