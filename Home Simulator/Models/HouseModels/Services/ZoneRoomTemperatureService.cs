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
        public void UpdateRoomTemperatures(SimulationViewModel simulationViewModel)
        {
            foreach (var zone in simulationViewModel.Zones)
            {
                var currentTime = simulationViewModel.SimulationModel.SimulationTime;
                foreach (var period in zone.TemperaturePeriods)
                {
                    if (currentTime >= period.StartTime && currentTime < period.EndTime)
                    {
                        foreach (var room in zone.Rooms)
                        {
                            room.RoomTemperature = period.DesiredTemperature;
                            simulationViewModel.AddLogMessage($"Room {room.Name} temperature set to {period.DesiredTemperature}°C");
                        }
                        break;
                    }
                }
            }
        }
        
        public void AdjustRoomTemperature(SimulationViewModel simulationViewModel)
        {
        bool isAllUsersOutdoor = simulationViewModel.users.All(user => user.CurrentLocation?.IsOutdoor == true);
         var currentTime = simulationViewModel.SimulationModel.SimulationTime;
         var currentDate = simulationViewModel.SimulationModel.SimulationDate;

            var isWinter = (currentDate >= new DateTime(currentDate.Year - 1, 12, 21) && currentDate <= new DateTime(currentDate.Year, 3, 21)) 
                     || (currentDate >= new DateTime(currentDate.Year, 12, 21) && currentDate <= new DateTime(currentDate.Year + 1, 3, 21));

                if (isWinter && isAllUsersOutdoor)
                {
                    foreach(var room in simulationViewModel.Rooms)
                    {
                        room.RoomTemperature = 17;
                        simulationViewModel.AddLogMessage($"Room {room.Name} temperature set to 17°C");
                    }
                }
        }
    }
}
