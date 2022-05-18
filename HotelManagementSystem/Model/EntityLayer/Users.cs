using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    public class Users : BasePropertyChanged
    {
        private int? id_user;
        private string first_name;
        private string second_name;
        private string email;
        private string password;
        private string username;
        private string phone;
        private DateTime birthday;
        private char sex;
        private string address;
        private Bitmap picture;
        private bool deleted;

        public int? IdUser
        {
            get
            {
                return id_user;
            }
            set
            {
                id_user = value;
                NotifyPropertyChanged("IdUser");
            }
        }

        public string FirstName
        {
            get { return first_name; }
            set
            {
                first_name = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get { return second_name; }
            set
            {
                second_name = value;
                NotifyPropertyChanged("SecondName");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged("Phone");
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                NotifyPropertyChanged("Birthday");
            }
        }

        private char Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                NotifyPropertyChanged("Sex");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public Bitmap Picture
        {
            get { return picture; }
            set
            {
                picture = value;
                NotifyPropertyChanged("Picture");
            }
        }

        public bool Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                NotifyPropertyChanged("Deleted");
            }
        }
    }
}
