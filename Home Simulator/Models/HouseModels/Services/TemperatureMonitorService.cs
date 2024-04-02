using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class TemperatureMonitorService
    {
        private readonly SimulationViewModel _simulationViewModel;

        public TemperatureMonitorService(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        // Indoor Room Temperature Monitoring
        public void CheckTemperatureChanges(Room room, double newTemperature)
        {
            double temperatureDifference = Math.Abs(newTemperature - room.LastKnownRoomTemperature);
            if (temperatureDifference >= 15)
            {
                HandleRapidTemperatureChange(room);
            }
        }

        private void HandleRapidTemperatureChange(Room room)
        {
            if (_simulationViewModel.IsAwayModeEnabled)
            {
                _simulationViewModel.IsAwayModeEnabled = false;
                LogEvent($"Away mode turned off due to rapid temperature change in {room.Name}.");
            }
        }


        //Outside Temperature Monitoring

        public void CheckOutsideTemperatureChanges(double newTemperature)
        {
            double temperatureDifference = Math.Abs(newTemperature - _simulationViewModel.OutsideTemperature);
            if (newTemperature >= 135)
            {
                HandleExtremeOutsideTemperature();
            }
        }

        private void HandleExtremeOutsideTemperature()
        {
            if (_simulationViewModel.IsAwayModeEnabled && _simulationViewModel.IsSimulationRunning)
            {
                _simulationViewModel.IsAwayModeEnabled = false;
                LogEvent("Away mode turned off due to extreme outside temperature.");
            }
        }


        private void LogEvent(string message)
        {
            _simulationViewModel.AddLogMessage(message);
        }



    }
}
