using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class OutsideTemperatureService
    {

        private SimulationViewModel _simulationViewModel;

        public OutsideTemperatureService(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public void UpdateOutsideTemperature()
        {
            if (_simulationViewModel.OutsideTemperatureData == null)
            {
                _simulationViewModel.OutsideTemperature = _simulationViewModel.OutsideTemperature; 
                return;
            }
            var currentDate = DateTime.ParseExact(_simulationViewModel.SimulationModel.GetCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            var currentHour = DateTime.ParseExact(_simulationViewModel.SimulationModel.GetCurrentTime(), "HH:mm:ss", CultureInfo.InvariantCulture).Hour;

            var temperatureData = _simulationViewModel.OutsideTemperatureData.FirstOrDefault(data =>
                data.dateTime.Date.ToString("yyyy-MM-dd") == currentDate &&
                data.dateTime.Hour == currentHour);

            if (temperatureData != default)
            {
                _simulationViewModel.OutsideTemperature = temperatureData.temperature;
                _simulationViewModel.AddLogMessage($"Outside temperature updated to {temperatureData.temperature}°C");
            }
            else
            {
                _simulationViewModel.OutsideTemperature = 10; 
            }
        }
    }
}
