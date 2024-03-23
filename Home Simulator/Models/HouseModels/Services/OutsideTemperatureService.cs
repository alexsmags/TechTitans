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
        public void UpdateOutsideTemperature(SimulationViewModel simulationViewModel)
        {
            if (simulationViewModel.OutsideTemperatureData == null)
            {
                simulationViewModel.OutsideTemperature = simulationViewModel.OutsideTemperature; 
                return;
            }
            var currentDate = DateTime.ParseExact(simulationViewModel.SimulationModel.GetCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            var currentHour = DateTime.ParseExact(simulationViewModel.SimulationModel.GetCurrentTime(), "HH:mm:ss", CultureInfo.InvariantCulture).Hour;

            var temperatureData = simulationViewModel.OutsideTemperatureData.FirstOrDefault(data =>
                data.dateTime.Date.ToString("yyyy-MM-dd") == currentDate &&
                data.dateTime.Hour == currentHour);

            if (temperatureData != default)
            {
                simulationViewModel.OutsideTemperature = temperatureData.temperature;
            }
            else
            {
                simulationViewModel.OutsideTemperature = 10; 
            }
        }
    }
}
