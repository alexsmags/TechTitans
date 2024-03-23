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
                        }
                        break;
                    }
                }
            }
        }
    }
}
