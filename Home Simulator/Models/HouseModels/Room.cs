using Home_Simulator.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class Room : Location
    {

        public List<Light> Lights { get; set; } = new List<Light>();

        public List<Door> Doors { get; set; } = new List<Door>();

        public List<Window> Windows { get; set; } = new List<Window>();

        public ObservableCollection<User> _usersInRoom { get; set; } = new ObservableCollection<User>();


        public ObservableCollection<User> UsersInRoom
        {
            get => _usersInRoom;
            set
            {
                _usersInRoom = value;
                OnPropertyChanged(nameof(UsersInRoom));
            }
        }

        public void AddUser(User user)
        {
            if (!_usersInRoom.Contains(user))
            {
                UsersInRoom.Add(user);
            }
        }

        public void RemoveUser(User user)
        {
            UsersInRoom.Remove(user);
        }

    }


}
