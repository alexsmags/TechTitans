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
        public void UpdateAirConditionerState(SimulationViewModel simulationViewModel)
        {
            var currentDate = DateTime.ParseExact(simulationViewModel.SimulationModel.GetCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            double roomAvgTemperature = calculateAverageTemperatureInRooms(simulationViewModel);
            double outsideTemperature = simulationViewModel.OutsideTemperature;
            bool isSummer = (currentDate >= new DateTime(currentDate.Year, 6, 21) && currentDate <= new DateTime(currentDate.Year, 9, 21));


            if (outsideTemperature < roomAvgTemperature && isSummer)
            {
                simulationViewModel.AirConditioner.TurnOffAC();
            }

        }

        private double calculateAverageTemperatureInRooms(SimulationViewModel simulationViewModel)
        {
            double totalRoomTemperature = 0;

            foreach(var room in simulationViewModel.Rooms)
            {
                totalRoomTemperature += room.RoomTemperature;
            }

            return totalRoomTemperature / simulationViewModel.Rooms.Count;
        }

        public void UpdateRoomTemperatures(SimulationViewModel simulationViewModel, AirConditioner airConditioner)
        {
            if (!airConditioner.IsOn) { return; }

            foreach (var zone in simulationViewModel.Zones)
            {
                foreach (var room in zone.Rooms)
                {
                    if (Math.Abs(room.RoomTemperature - airConditioner.DesiredTemperature) >= 0.25)
                    {
                        double temperatureChange = (room.RoomTemperature < airConditioner.DesiredTemperature) ? 0 : -0.1;
                        room.RoomTemperature += temperatureChange;

                        if ((temperatureChange > 0 && room.RoomTemperature > airConditioner.DesiredTemperature) ||
                            (temperatureChange < 0 && room.RoomTemperature < airConditioner.DesiredTemperature))
                        {
                            room.RoomTemperature = airConditioner.DesiredTemperature;
                        }
                    }
                }
            }
        }
    }
}
