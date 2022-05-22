using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Model.EntityLayer
{
    class Room : BasePropertyChanged
    {
        private int id;
        private string name;
        private int number;
        private List<Price> prices;
        private List<Feature> features;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Number { get { return number; } set { number = value; } }
        public List<Price> Prices { get { return prices; } set { prices = value; } }
        public List <Feature> Features { get { return features; } set { features = value; } }

    }
}
