using Home_Simulator.Models.HouseSimulationModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class Zone : INotifyPropertyChanged
    {
        private string _name;

        public ObservableCollection<TemperaturePeriodModel> TemperaturePeriods { get; set; } = new ObservableCollection<TemperaturePeriodModel>();

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

        public Zone(string name)
        {
            _name = name;
        }

        public void AddRoom(Room room)
        {
            if (!Rooms.Contains(room))
            {
                Rooms.Add(room);
                room.AssignedZone = this;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
