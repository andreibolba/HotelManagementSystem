﻿using HotelManagementSystem.Model.DataAccessLayer;
using HotelManagementSystem.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.BusinessLogicLayer
{
    public class UsersBLL
    {
        public ObservableCollection<Users> UsersList { get; set; }

        UsersDAL userDAL = new UsersDAL();

        public ObservableCollection<Users> GetAllPersons()
        {
            return userDAL.GetAllUsers();
        }

        public Users getLoggedUser(string email,string password)
        {
            return userDAL.logInUser(email, password);
        }
    }
}
