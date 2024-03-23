﻿using Home_Simulator.ViewModels;
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

        public void AdjustRoomTemperature(SimulationViewModel simulationViewModel)
        {
            bool isAllUserOutdoor = simulationViewModel.users.All(u => u.CurrentLocation?.IsOutdoor ?? true);


            

            foreach (var zone in simulationViewModel.Zones)
            {
                var currentTime = simulationViewModel.SimulationModel.SimulationTime;
                var currentDate = simulationViewModel.SimulationModel.SimulationDate;

                var isWinter =
                        (currentDate >= new DateTime(currentDate.Year - 1, 12, 21) && currentDate <= new DateTime(currentDate.Year, 3, 21))
                        || (currentDate >= new DateTime(currentDate.Year, 12, 21) && currentDate <= new DateTime(currentDate.Year + 1, 3, 21));

                foreach (var period in zone.TemperaturePeriods)
                {
                    if (currentTime >= period.StartTime && currentTime < period.EndTime)
                    {
                        foreach (var room in zone.Rooms)
                        {
                            room.RoomTemperature = isWinter && isAllUserOutdoor && !room.IsOutdoor ? 17.0 : period.DesiredTemperature;
                        }
                        break;
                    }
                }
            }
        }
    }
}
