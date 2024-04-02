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
        private SimulationViewModel _simulationViewModel;

        public HeatingService(SimulationViewModel simulationViewModel) 
        { 
            _simulationViewModel = simulationViewModel;
        }

        public void UpdateRoomTemperatures()
        {
            if (!_simulationViewModel.Heater.IsOn) { return; }

            foreach (var zone in _simulationViewModel.Zones)
            {
                foreach (var room in zone.Rooms)
                {
                    if (Math.Abs(room.RoomTemperature - _simulationViewModel.Heater.DesiredTemperature) >= 0.25)
                    {
                        double temperatureChange = (room.RoomTemperature > _simulationViewModel.Heater.DesiredTemperature) ? 0 : +0.1;
                        room.RoomTemperature += temperatureChange;
                        room.LastKnownRoomTemperature += temperatureChange;

                        if ((temperatureChange > 0 && room.RoomTemperature > _simulationViewModel.Heater.DesiredTemperature) ||
                            (temperatureChange < 0 && room.RoomTemperature < _simulationViewModel.Heater.DesiredTemperature))
                        {
                            room.RoomTemperature = _simulationViewModel.Heater.DesiredTemperature;
                            room.LastKnownRoomTemperature = _simulationViewModel.Heater.DesiredTemperature;
                        }
                    }
                }
            }
        }
    }
}
