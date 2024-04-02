using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class TogglePoliceTimerCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public TogglePoliceTimerCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            _simulationViewModel.IsPoliceTimerActive = !_simulationViewModel.IsPoliceTimerActive;
            _simulationViewModel.AddLogMessage($"Police timer is now {(_simulationViewModel.IsPoliceTimerActive ? "enabled" : "disabled")}.");
        }
    }
}
