using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class ZoneRoomTemperatureService
    {
        private SimulationViewModel _simulationViewModel;
        private AirConditioner _airConditioner;

        public ZoneRoomTemperatureService(SimulationViewModel simulationViewModel, AirConditioner airConditioner)
        {
            _simulationViewModel = simulationViewModel;
            _airConditioner = airConditioner;
        }

        public void UpdateRoomTemperatures()
        {
            foreach (var zone in _simulationViewModel.Zones)
            {
                var currentTime = _simulationViewModel.SimulationModel.SimulationTime;
                foreach (var period in zone.TemperaturePeriods)
                {
                    if (currentTime >= period.StartTime && currentTime < period.EndTime)
                    {
                        foreach (var room in zone.Rooms)
                        {
                            if (_airConditioner.IsOn)
                            {
                                room.RoomTemperature = period.DesiredTemperature + 0.1;
                                continue;
                            }
                            room.RoomTemperature = period.DesiredTemperature;
                            room.LastKnownRoomTemperature = period.DesiredTemperature;
                            _simulationViewModel.AddLogMessage($"Room {room.Name} temperature set to {period.DesiredTemperature}°C");
                        }
                        break;
                    }
                }
            }
        }
        
        public void AdjustRoomTemperature()
        {
        bool isAllUsersOutdoor = _simulationViewModel.users.All(user => user.CurrentLocation?.IsOutdoor == true);
         var currentTime = _simulationViewModel.SimulationModel.SimulationTime;
         var currentDate = _simulationViewModel.SimulationModel.SimulationDate;

            var isWinter = (currentDate >= new DateTime(currentDate.Year - 1, 12, 21) && currentDate <= new DateTime(currentDate.Year, 3, 21)) 
                     || (currentDate >= new DateTime(currentDate.Year, 12, 21) && currentDate <= new DateTime(currentDate.Year + 1, 3, 21));

                if (isWinter && isAllUsersOutdoor)
                {
                    foreach(var room in _simulationViewModel.Rooms)
                    {
                        room.RoomTemperature = 17;
                        room.LastKnownRoomTemperature = 17;
                        _simulationViewModel.AddLogMessage($"Room {room.Name} temperature set to 17°C");
                    }
                }
        }
    }
}
