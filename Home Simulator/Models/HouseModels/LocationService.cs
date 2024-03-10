using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class LocationService
    {
        public List<Location> Locations { get; set; } = new List<Location>();


        public LocationService() 
        {
            Locations.Add(new OutdoorLocation()); 
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public void AddRooms(ObservableCollection<Room> rooms)
        {
            foreach (var room in rooms)
            {
                Locations.Add(room);
            }
        }

        public void RemoveLocation(Location location)
        {
            Locations.Remove(location); 
        }

        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

        // Since there's only one outdoor location, this doesn't need to be a collection
        public OutdoorLocation OutdoorLocation { get; private set; }


    }
}
