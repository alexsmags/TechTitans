using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class AirConditionerService
    {
        private SimulationViewModel _simulationViewModel;  
        
        public AirConditionerService(SimulationViewModel simulationViewModel) 
        {
            _simulationViewModel = simulationViewModel;
        }

        public void UpdateAirConditionerState()
        {
            var currentDate = DateTime.ParseExact(_simulationViewModel.SimulationModel.GetCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            double roomAvgTemperature = calculateAverageTemperatureInRooms();
            double outsideTemperature = _simulationViewModel.OutsideTemperature;
            bool isSummer = (currentDate >= new DateTime(currentDate.Year, 6, 21) && currentDate <= new DateTime(currentDate.Year, 9, 21));


            if (outsideTemperature < roomAvgTemperature && isSummer)
            {
                _simulationViewModel.AirConditioner.TurnOffAC();
            }

          

        }

        public void UpdateRoomTemperatures(SimulationViewModel simulationViewModel)
        {
            if (!_simulationViewModel.AirConditioner.IsOn) { return; }

            foreach (var zone in simulationViewModel.Zones)
            {
                foreach (var room in zone.Rooms)
                {
                    if (Math.Abs(room.RoomTemperature - _simulationViewModel.AirConditioner.DesiredTemperature) >= 0.25)
                    {
                        double temperatureChange = (room.RoomTemperature < _simulationViewModel.AirConditioner.DesiredTemperature) ? 0 : -0.1;
                        room.RoomTemperature += temperatureChange;
                        room.LastKnownRoomTemperature += temperatureChange;

                        if ((temperatureChange > 0 && room.RoomTemperature > _simulationViewModel.AirConditioner.DesiredTemperature) ||
                            (temperatureChange < 0 && room.RoomTemperature < _simulationViewModel.AirConditioner.DesiredTemperature))
                        {
                            room.RoomTemperature = _simulationViewModel.AirConditioner.DesiredTemperature;
                            room.LastKnownRoomTemperature = _simulationViewModel.AirConditioner.DesiredTemperature;
                        }
                    }
                }
            }
        }

        private double calculateAverageTemperatureInRooms()
        {
            double totalRoomTemperature = 0;

            foreach (var room in _simulationViewModel.Rooms)
            {
                totalRoomTemperature += room.RoomTemperature;
            }

            return totalRoomTemperature / _simulationViewModel.Rooms.Count;
        }
    }
}
