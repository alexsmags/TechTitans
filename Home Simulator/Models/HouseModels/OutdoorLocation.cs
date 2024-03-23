using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class OutdoorLocation : Location
    {
        public OutdoorLocation() 
        {
            Name = "Outdoor";
            IsOutdoor = true;

        }

	}
}
