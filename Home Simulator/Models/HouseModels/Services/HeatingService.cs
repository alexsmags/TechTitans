using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class HeatingService
    {

        public void UpdateRoomTemperatures(SimulationViewModel simulationViewModel, Heater heater)
        {
            if (!heater.IsOn) { return; }

            foreach (var zone in simulationViewModel.Zones)
            {
                foreach (var room in zone.Rooms)
                {
                    if (Math.Abs(room.RoomTemperature - heater.DesiredTemperature) >= 0.25)
                    {
                        double temperatureChange = (room.RoomTemperature > heater.DesiredTemperature) ? 0 : +0.1;
                        room.RoomTemperature += temperatureChange;

                        if ((temperatureChange > 0 && room.RoomTemperature > heater.DesiredTemperature) ||
                            (temperatureChange < 0 && room.RoomTemperature < heater.DesiredTemperature))
                        {
                            room.RoomTemperature = heater.DesiredTemperature;
                        }
                    }
                }
            }
        }
    }
}
