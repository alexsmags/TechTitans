using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class ToggleAcCommand : CommandBase
    {

        private SimulationViewModel _simulationViewModel;

        public ToggleAcCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_simulationViewModel.AirConditioner.IsOn)
            {
                _simulationViewModel.AirConditioner.TurnOffAC();
            }
            else
            {
                _simulationViewModel.AirConditioner.TurnOnAC();
            }
        }
    }
}
