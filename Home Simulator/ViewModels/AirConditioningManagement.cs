using Home_Simulator.HouseSimulationModels;
using System;

namespace Home_Simulator.ViewModels
{
    public class AirConditioningManagementViewModel
    {
        private IWeatherService _weatherService;
        private IAirConditioningController _airConditioningController;

        public AirConditioningManagementViewModel(
            IWeatherService weatherService,
            IAirConditioningController airConditioningController)
        {
            _weatherService = weatherService;
            _airConditioningController = airConditioningController;
        }

        public void CheckAndManageAirConditioning()
        {
            if (IsSummerTime() && _airConditioningController.IsAirConditioningOn())
            {
                double outsideTemperature = _weatherService.GetOutsideTemperature();
                double insideTemperature = _airConditioningController.GetInsideTemperature();

                if (outsideTemperature < insideTemperature)
                {
                    _airConditioningController.Shutdown();
                }
            }
        }

        private bool IsSummerTime()
        {
            // Assuming Northern Hemisphere summer months: June 1st to August 31st
            var currentDate = DateTime.Now;
            return currentDate.Month >= 6 && currentDate.Month <= 8;
        }
    }
}