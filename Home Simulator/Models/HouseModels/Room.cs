using Home_Simulator.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class Room : Location
    {
        private bool _isAutomationEnabled;

        public List<Light> Lights { get; set; } = new List<Light>();

        public List<Door> Doors { get; set; } = new List<Door>();

        public List<Window> Windows { get; set; } = new List<Window>();

        public ObservableCollection<User> _usersInRoom { get; set; } = new ObservableCollection<User>();

        public bool IsAutomationEnabled
        {
            get => _isAutomationEnabled;
            
            set
            {
                _isAutomationEnabled = value;
                OnPropertyChanged(nameof(IsAutomationEnabled));
            }
        }


        public ObservableCollection<User> UsersInRoom
        {
            get => _usersInRoom;
            set
            {
                _usersInRoom = value;
                OnPropertyChanged(nameof(UsersInRoom));
            }
        }

        public Room()
        {
            UsersInRoom.CollectionChanged += UsersInRoom_CollectionChanged;
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

        private void UsersInRoom_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!IsAutomationEnabled) return;

            var anyUserPresent = UsersInRoom.Any();
            foreach (var light in Lights)
            {
                if (anyUserPresent)
                {
                    light.SwitchOn();
                }
                
                else
                {
                    light.SwitchOff();  
                }
            }
        }

    }


}
