using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class HouseData
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public AirConditioner AirConditioner { get; set; }

        public Heater Heater { get; set; }
    }

}
