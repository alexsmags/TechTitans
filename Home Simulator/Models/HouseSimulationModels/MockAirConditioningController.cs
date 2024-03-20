namespace Home_Simulator.HouseSimulationModels
{
    public class MockAirConditioningController : IAirConditioningController
    {
        private double _insideTemperature;
        private bool _isOn = true;

        public MockAirConditioningController(double insideTemperature)
        {
            _insideTemperature = insideTemperature;
        }

        public void Shutdown()
        {
            _isOn = false;
            Console.WriteLine("Air conditioning has been shut down.");
        }

        public double GetInsideTemperature()
        {
            return _insideTemperature;
        }

        public void SetInsideTemperature(double temperature)
        {
            _insideTemperature = temperature;
        }

        public bool IsAirConditioningOn()
        {
            return _isOn;
        }

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Air conditioning has been turned on.");
        }
    }
}