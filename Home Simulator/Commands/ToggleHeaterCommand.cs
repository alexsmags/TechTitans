using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class ToggleHeaterCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public ToggleHeaterCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_simulationViewModel.Heater.IsOn)
            {
                _simulationViewModel.Heater.TurnOffHeater();
                _simulationViewModel.AddLogMessage($"Heater {_simulationViewModel.Heater.HeaterName} turned off");
            }
            else
            {
                if (_simulationViewModel.AirConditioner.IsOn)
                {
                    _simulationViewModel.AirConditioner.TurnOffAC();
                    _simulationViewModel.AddLogMessage($"Air Conditioner {_simulationViewModel.AirConditioner.ACName} turned off");
                }
                _simulationViewModel.Heater.TurnOnHeater();
                _simulationViewModel.AddLogMessage($"Heater {_simulationViewModel.Heater.HeaterName} turned on");
            }
        }
    }
}
