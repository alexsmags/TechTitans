namespace Home_Simulator.HouseSimulationModels
{
    public interface IAirConditioningController
    {
        void Shutdown();
        double GetInsideTemperature();
        bool IsAirConditioningOn();
        void TurnOn();
    }
}