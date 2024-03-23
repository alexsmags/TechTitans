namespace Home_Simulator.Models.HouseSimulationModels
{
    public class MockWeatherService : IWeatherService
    {
        private double _outsideTemperature;

        public MockWeatherService(double outsideTemperature)
        {
            _outsideTemperature = outsideTemperature;
        }

        public double GetOutsideTemperature()
        {
            return _outsideTemperature;
        }

        public void SetOutsideTemperature(double temperature)
        {
            _outsideTemperature = temperature;
        }
    }
}