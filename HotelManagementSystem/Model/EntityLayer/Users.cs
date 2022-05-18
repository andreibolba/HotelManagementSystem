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
        private string sex;
        private string address;
        private Bitmap picture;
        private string deleted;

        public Users()
        {
            id_user = -1;
            first_name = string.Empty;
            second_name = string.Empty;
            email = string.Empty;
            password = string.Empty;
            username = string.Empty;
            phone = string.Empty;
            birthday = DateTime.MinValue;
            sex = string.Empty;
            address = string.Empty;
            deleted = string.Empty;
            picture = null;

        }

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

        public string Sex
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

        public string Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                NotifyPropertyChanged("Deleted");
            }
        }

        public override string ToString()
        {
            string write=null;
            write += id_user.ToString()+"\n";
            write += first_name.ToString() + "\n";
            write += second_name.ToString() + "\n";
            write += username.ToString() + "\n";
            write += email.ToString() + "\n";
            write += password.ToString() + "\n";
            write += address.ToString() + "\n";
            write += phone.ToString() + "\n";
            return write;
        }
    }
}
